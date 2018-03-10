using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface ISessionsService
    {
        [ItemNotNull]
        Task<IEnumerable<ServiceModel>> GetServises(int sessionId);

        [ItemNotNull]
        Task<IEnumerable<SessionModelResponse>> GetSessions();
    }
}
