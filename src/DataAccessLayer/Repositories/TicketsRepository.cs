using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Dapper;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using DataAccessLayer.Models.Entities;
using JetBrains.Annotations;

namespace DataAccessLayer.Repositories
{
    internal class TicketsRepository : ITicketsRepository
    {
        [NotNull]
        private readonly IDalSettings _settings;


        public TicketsRepository([NotNull] IDalSettings settings)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<TicketDalDtoModelResponse>> GetTicketsForUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<TicketDalModelResponse> tickets = await connection.QueryAsync<TicketDalModelResponse>(
                    "GetTicketsForUser",
                    new
                        {
                            UserId = id
                        },
                    commandType: CommandType.StoredProcedure);

                return tickets.Select(Mapper.Map<TicketDalDtoModelResponse>);
            }
        }

        public async Task<TicketDalDtoModelResponse> GetTicketById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                TicketDalModelResponse ticket = await connection.QuerySingleOrDefaultAsync<TicketDalModelResponse>(
                    "GetTicketById",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);

                return Mapper.Map<TicketDalDtoModelResponse>(ticket);
            }
        }

        public async void CreateTicket(TicketDalDtoModelRequest ticket)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                await connection.ExecuteAsync(
                    "AddTicket",
                    new
                        {
                            UserId = ticket.UserId,
                            PriceId = ticket.PriceId,
                            TicketStatus = ticket.Status.ToString()
                        },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async void AddServiceToTicket(int ticketId, int serviceId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                await connection.ExecuteAsync(
                    "AddServiceForTicket",
                    new
                        {
                            TicketId = ticketId,
                            ServiceId = serviceId
                        },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TicketDalDtoModelResponse> PayForTicket(int ticketId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "PayForTicket",
                    new
                        {
                            TicketStatus = TicketStatus.Paid.ToString(),
                            TicketId = ticketId
                        },
                    commandType: CommandType.StoredProcedure);

                return await GetTicketById(id);
            }
        }
        public async void DeleteTicket(int id)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                await connection.ExecuteAsync(
                    "DeleteTicket",
                    new
                        {
                            Id = id
                        },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
