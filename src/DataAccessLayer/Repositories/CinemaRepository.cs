using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using DataAccessLayer.Models.Entities;
using JetBrains.Annotations;

namespace DataAccessLayer.Repositories
{
    [UsedImplicitly]
    internal class CinemaRepository : ICinemaRepository
    {
        [NotNull]
        private readonly IDalSettings _settings;

        public CinemaRepository([NotNull] IDalSettings settings)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<CinemaResponse>> GetCinemas()
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Cinema> cinemas = await connection.QueryAsync<Cinema>(
                    "GetCinemas",
                    commandType: CommandType.StoredProcedure);

                return cinemas.Select(Mapper.Map<CinemaResponse>);
            }
        }

        public async Task<CinemaResponse> GetCinemaById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                Cinema cinema = await connection.QuerySingleOrDefaultAsync<Cinema>(
                    "GetCinemaById",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);

                return Mapper.Map<CinemaResponse>(cinema);
            }
        }

        public async Task<int> AddCinema(CinemaRequest cinema)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddCinema",
                    new
                        {
                            Name = cinema.Name,
                            City = cinema.City
                        },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public async Task<HttpStatusCode> DeleteCinema(int id)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int result = await connection.ExecuteScalarAsync<int>(
                    "DeleteCinema",
                    new
                        {
                            Id = id
                        },
                    commandType: CommandType.StoredProcedure);

                if (result == 1)
                    return HttpStatusCode.NoContent;
            }

            return HttpStatusCode.NotFound;
        }
    }
}
