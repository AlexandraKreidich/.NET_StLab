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

        public async Task<IEnumerable<CinemaModel>> GetCinemas()
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Cinema> cinemas = await connection.QueryAsync<Cinema>(
                    "GetCinemas",
                    commandType: CommandType.StoredProcedure);

                return cinemas.Select(Mapper.Map<CinemaModel>);
            }
        }

        public async Task<CinemaModel> GetCinemaById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                Cinema cinema = await connection.QuerySingleOrDefaultAsync<Cinema>(
                    "GetCinemaById",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);

                return Mapper.Map<CinemaModel>(cinema);
            }
        }

        public async Task<int> AddOrUpdateCinema(CinemaModel cinema)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddOrUpdateCinema",
                    new
                        {
                            Id = cinema.Id,
                            Name = cinema.Name,
                            City = cinema.City
                        },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public async Task<IEnumerable<HallModel>> GetHalls(int cinemaId)
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

                return halls.Select(Mapper.Map<HallModel>);
            }
        }

        public async Task<IEnumerable<PlaceModel>> GetPlaces(int hallId)
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

                return places.Select(Mapper.Map<PlaceModel>);
            }
        }

        public async Task<IEnumerable<HallSchemeModel>> GetHallScheme(int hallId)
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

                return scheme.Select(Mapper.Map<HallSchemeModel>);
            }
        }
    }
}
