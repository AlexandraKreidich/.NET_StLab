using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public async Task<IEnumerable<HallResponse>> GetHalls(int cinemaId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Hall> halls = await connection.QueryAsync<Hall>(
                    "GetHalls",
                    new
                        {
                            CinemaId = cinemaId
                        },
                    commandType: CommandType.StoredProcedure);

                return halls.Select(Mapper.Map<HallResponse>);
            }
        }

        public async Task<IEnumerable<PlaceResponse>> GetPlaces(int hallId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Place> places = await connection.QueryAsync<Place>(
                    "GetPlaces",
                    new
                        {
                            HallId = hallId
                        },
                    commandType: CommandType.StoredProcedure);

                return places.Select(Mapper.Map<PlaceResponse>);
            }
        }

        public async Task<IEnumerable<HallSchemeResponse>> GetHallScheme(int hallId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<HallScheme> scheme = await connection.QueryAsync<HallScheme>(
                    "GetHallScheme",
                    new
                        {
                            HallId = hallId
                        },
                    commandType: CommandType.StoredProcedure);

                return scheme.Select(Mapper.Map<HallSchemeResponse>);
            }
        }
    }
}
