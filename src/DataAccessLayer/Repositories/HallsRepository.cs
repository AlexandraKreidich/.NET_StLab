using System.Data;
using System.Data.SqlClient;
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
    internal class HallsRepository : IHallsRepository
    {
        [NotNull]
        private readonly IDalSettings _settings;

        public HallsRepository([NotNull] IDalSettings settings)
        {
            _settings = settings;
        }

        public async Task<HallModel> GetHall(int id)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                Hall hall = await connection.QuerySingleOrDefaultAsync<Hall>(
                    "GetHallById",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);

                return Mapper.Map<HallModel>(hall);
            }
        }

        public async Task<int> AddOrUpdateHall(HallModel hall)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddOrUpdateHall",
                    new
                    {
                        Id = hall.Id,
                        CinemaId = hall.CinemaId,
                        Name = hall.Name
                    },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public async Task<int> AddOrUpdateHallScheme(HallSchemeModel hallScheme)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddOrUpdateHallScheme",
                    new
                    {
                        Id = hallScheme.Id,
                        HallId = hallScheme.HallId,
                        RowNumber = hallScheme.RowNumber,
                        PlacesCount = hallScheme.PlacesCount
                    },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public async Task<int> AddOrUpdatePlace(PlaceModel place)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddOrUpdatePlace",
                    new
                    {
                        Id = place.Id,
                        HallId = place.HallId,
                        PlaceType = place.Type,
                        PlaceNumber = place.PlaceNumber,
                        RowNumber = place.RowNumber
                    },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }
    }
}
