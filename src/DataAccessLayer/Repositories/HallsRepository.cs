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

        public async Task<HallDalDtoModel> GetHall(int id)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                HallDalModel hallDalModel = await connection.QuerySingleOrDefaultAsync<HallDalModel>(
                    "GetHallById",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);

                return Mapper.Map<HallDalDtoModel>(hallDalModel);
            }
        }

        public async Task<int> AddOrUpdateHall(HallDalDtoModel hallDalDto)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddOrUpdateHall",
                    new
                    {
                        Id = hallDalDto.Id,
                        CinemaId = hallDalDto.CinemaId,
                        Name = hallDalDto.Name
                    },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public async Task<int> AddOrUpdateHallScheme(HallSchemeDalDtoModel hallSchemeDalDto)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddOrUpdateHallScheme",
                    new
                    {
                        Id = hallSchemeDalDto.Id,
                        HallId = hallSchemeDalDto.HallId,
                        RowNumber = hallSchemeDalDto.RowNumber,
                        PlacesCount = hallSchemeDalDto.PlacesCount
                    },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public async Task<int> AddOrUpdatePlace(PlaceDalDtoModel placeDalDto)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddOrUpdatePlace",
                    new
                    {
                        Id = placeDalDto.Id,
                        HallId = placeDalDto.HallId,
                        PlaceTypeId = placeDalDto.TypeId,
                        PlaceNumber = placeDalDto.PlaceNumber,
                        RowNumber = placeDalDto.RowNumber
                    },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }
    }
}
