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
using SessionModelRequest = DataAccessLayer.Models.DataTransferObjects.SessionModelRequest;

namespace DataAccessLayer.Repositories
{
    [UsedImplicitly]
    internal class SessionsRepository : ISessionsRepository
    {
        [NotNull]
        private readonly IDalSettings _settings;

        public SessionsRepository([NotNull] IDalSettings settings)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<ServiceModel>> GetServises(int sessionId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Service> services = await connection.QueryAsync<Service>(
                    "GetServicesForSession",
                    new
                        {
                            SessionId = sessionId
                        },
                    commandType: CommandType.StoredProcedure);

                return services.Select(Mapper.Map<ServiceModel>);
            }
        }

        public async Task<IEnumerable<SessionModelResponse>> GetSessions()
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<SessionResponse> sessions = await connection.QueryAsync<SessionResponse>(
                    "GetSessions",
                    commandType: CommandType.StoredProcedure);

                return sessions.Select(Mapper.Map<SessionModelResponse>);
            }
        }

        public Task<SessionModelResponse> AddOrUpdateSession(SessionModelRequest session)
        {
            throw new System.NotImplementedException();
        }

        public Task<SessionServiceModel> AddOrUpdateService(SessionServiceModel service)
        {
            throw new System.NotImplementedException();
        }

        public Task<SessionModelResponse> AddOrUpdateSession(SessionModelRequest session, SessionServiceModel services)
        {
            throw new System.NotImplementedException();
        }
    }
}
