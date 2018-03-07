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
                Hall cinema = await connection.QuerySingleOrDefaultAsync<Hall>(
                    "GetHallById",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);

                return Mapper.Map<HallModel>(cinema);
            }
        }
    }
}
