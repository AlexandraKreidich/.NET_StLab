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
        Task<int> AddOrUpdateSession(SessionModelRequest session);

        void DeleteServiceFromSession(int sessionId);

        [ItemNotNull]
        Task<int> AddServiceToSession(SessionServiceModel service);

        void DeleteSession(int id);
    }
}
