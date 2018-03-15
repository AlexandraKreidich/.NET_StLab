using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface ISessionsRepository
    {
        [ItemNotNull]
        Task<IEnumerable<ServiceModel>> GetServices(int sessionId);

        [ItemNotNull]
        Task<IEnumerable<SessionModelResponse>> GetSessions();

        [ItemCanBeNull]
        Task<SessionModelResponse> GetSessionById(int id);

        Task<int> AddOrUpdateSession([NotNull] SessionModelRequest session);

        void AddOrUpdatePriceForSession(int sessionId, int placeId, decimal price);

        void DeleteServiceFromSession(int sessionId);

        void AddServiceToSession([NotNull] SessionServiceModel service);

        void DeleteSession(int id);
    }
}
