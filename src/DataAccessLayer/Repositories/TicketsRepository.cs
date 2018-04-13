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
    [UsedImplicitly]
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

        public async Task<IEnumerable<ServiceDalDtoModelResponseForTicket>> GetServicesForTicket(int ticketId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<ServiceDalModelResponseForTicket> services = await connection.QueryAsync<ServiceDalModelResponseForTicket>(
                    "GetServicesForTicketId",
                    new
                        {
                            TicketId = ticketId
                        },
                    commandType: CommandType.StoredProcedure);

                return services.Select(Mapper.Map<ServiceDalDtoModelResponseForTicket>);
            }
        }

        public async Task<CreateTicketResponseDalDtoModel> CreateTicket(TicketDalDtoModelRequest ticket)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
                {
                    int id = await connection.ExecuteScalarAsync<int>(
                        "AddTicket",
                        new
                        {
                            UserId = ticket.UserId,
                            PriceId = ticket.PriceId,
                            TicketStatus = TicketStatus.InProcess.ToString()
                        },
                        commandType: CommandType.StoredProcedure);

                    return new CreateTicketResponseDalDtoModel(StoredProcedureExecutionResult.Ok, id);
                }
            }
            catch (SqlException e) when (e.Number == 2627) // Unique key violation
            {
                return new CreateTicketResponseDalDtoModel(StoredProcedureExecutionResult.UniqueKeyViolation, 0);
            }
        }

        public async void AddServiceToTicket([NotNull] ServiceDalDtoModelRequestForTicket service)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                await connection.ExecuteAsync(
                    "AddServiceForTicket",
                    new
                        {
                            TicketId = service.TicketId,
                            ServiceId = service.ServiceId,
                            Amount = service.Amount
                        },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async void PayForTicket(int ticketId)
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

        public async void ClearBookedTickets()
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                await connection.ExecuteAsync(
                    "ClearBookedTickets",
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
