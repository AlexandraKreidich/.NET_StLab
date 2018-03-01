using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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

        public IEnumerable<CinemaResponse> GetCinemas()
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Cinema> cinemas = connection.Query<Cinema>(
                    "GetCinemas",
                    commandType: CommandType.StoredProcedure);

                return cinemas.Select(Mapper.Map<CinemaResponse>);
            }
        }

        public CinemaResponse GetCinemaById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                Cinema cinema = connection.QuerySingleOrDefault<Cinema>(
                    "GetCinemaById",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);

                return Mapper.Map<CinemaResponse>(cinema);
            }
        }

        public int AddCinema(CinemaRequest cinema)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = connection.ExecuteScalar<int>(
                    "AddCinema",
                    new
                        {
                            cinema.Name,
                            cinema.City
                        },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public HttpStatusCode DeleteCinema(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
