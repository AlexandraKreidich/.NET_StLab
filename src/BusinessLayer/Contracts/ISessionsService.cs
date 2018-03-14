using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface ISessionsService
    {
        [ItemCanBeNull]
        Task<IEnumerable<ServiceModel>> GetServices(int sessionId);

        [ItemNotNull]
        Task<IEnumerable<SessionModelResponse>> GetSessions();

        [ItemCanBeNull]
        Task<SessionModelResponse> GetSessionById(int id);

        [ItemNotNull]
        Task<SessionModelResponse> AddOrUpdateSession(SessionModelRequest session);

        void AddOrUpdatePriceForSession(PriceRequestForSessionController price);

        void DeleteSession(int id);
    }
}
