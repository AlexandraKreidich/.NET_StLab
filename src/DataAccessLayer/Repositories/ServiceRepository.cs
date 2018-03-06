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
    internal class ServiceRepository : IServiceRepository
    {
        [NotNull]
        private readonly IDalSettings _settings;

        public ServiceRepository([NotNull] IDalSettings settings)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<ServiceModel>> GetServices()
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Service> services = await connection.QueryAsync<Service>(
                    "GetServices",
                    commandType: CommandType.StoredProcedure);

                return services.Select(Mapper.Map<ServiceModel>);
            }
        }

        public async Task<int> AddOrUpdateService(ServiceModel service)
        {
            Service serviceRequest = Mapper.Map<Service>(service);

            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddOrUpdateService",
                    new
                    {
                        Id = serviceRequest.Id,
                        Name = serviceRequest.Name,
                        Price = serviceRequest.Price
                    },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public async Task<StoredProcedureExecutionResult> DeleteService(int id)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                try
                {
                   await connection.ExecuteAsync(
                        "DeleteService",
                        new
                            {
                                Id = id,
                            },
                        commandType: CommandType.StoredProcedure);

                    return StoredProcedureExecutionResult.Ok;
                }
                catch (SqlException e) when (e.Number == 547) // Foreign key violation
                {
                    return StoredProcedureExecutionResult.ForeignKeyViolation;
                }
            }
        }
    }
}
