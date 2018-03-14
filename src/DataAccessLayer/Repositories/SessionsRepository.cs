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

        public async Task<int> AddOrUpdateSession(SessionModelRequest session)
        {
            int id;

            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                id = await connection.ExecuteScalarAsync<int>(
                    "AddOrUpdateSession",
                    new
                        {
                            Id = session.Id,
                            FilmId = session.FilmId,
                            HallId = session.HallId,
                            Date = session.Time
                        },
                    commandType: CommandType.StoredProcedure);
            }
            // нужно добавить новые сервисы и потом какой должен быть возвращаемый результат определить
            // создать модель и вернуть в ней массив новых сервисов или просто вернуть модель или сделать еще один запрос потом просто

            return id;
        }

        public async void DeleteServiceFromSession(int sessionId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                await connection.ExecuteAsync(
                    "DeleteServicesFromSession",
                    new
                        {
                            SessionId = sessionId,
                        },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> AddServiceToSession(SessionServiceModel service)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddServiceForSession",
                    new
                        {
                            SessionId = service.SessionId,
                            ServiceId = service.ServiceId
                        },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public async void DeleteSession(int id)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                await connection.ExecuteAsync(
                    "DeleteSession",
                    new
                        {
                            Id = id,
                        },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
