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
    internal class ServiceRepository : IServiceRepository
    {
        [NotNull]
        private readonly IDalSettings _settings;

        public ServiceRepository([NotNull] IDalSettings settings)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<ServiceResponse>> GetServices()
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Service> services = await connection.QueryAsync<Service>(
                    "GetServices",
                    commandType: CommandType.StoredProcedure);

                return services.Select(Mapper.Map<ServiceResponse>);
            }
        }

        public async Task<int> AddService(ServiceRequest service)
        {
            Service serviceToAdd = Mapper.Map<Service>(service);

            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddService",
                    new
                    {
                        Name = serviceToAdd.Name,
                        Price = serviceToAdd.Price
                    },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }
    }
}
