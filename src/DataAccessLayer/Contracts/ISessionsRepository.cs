using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface ISessionsRepository
    {
        [ItemNotNull]
        Task<IEnumerable<ServiceModel>> GetServises(int sessionId);

        [ItemNotNull]
        Task<IEnumerable<SessionModelResponse>> GetSessions();

        [ItemNotNull]
        Task<SessionModelResponse> AddOrUpdateSession(SessionModelRequest session);

        [ItemNotNull]
        Task<SessionServiceModel> AddOrUpdateService(SessionServiceModel service);
    }
}
