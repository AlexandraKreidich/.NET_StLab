using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using BlServiceModel = DataAccessLayer.Models.DataTransferObjects.ServiceModel;
using BlSessionModelResponse = DataAccessLayer.Models.DataTransferObjects.SessionModelResponse;

namespace BusinessLayer.Services
{
    internal class SessionsService : ISessionsService
    {
        [NotNull] 
        private readonly ISessionsRepository _sessionRepository;

        public SessionsService([NotNull] ISessionsRepository sessionsRepository)
        {
            _sessionRepository = sessionsRepository;
        }

        public async Task<IEnumerable<ServiceModel>> GetServises(int sessionId)
        {
            IEnumerable<BlServiceModel> services = await _sessionRepository.GetServises(sessionId);

            return services.Select(Mapper.Map<ServiceModel>);
        }

        public async Task<IEnumerable<SessionModelResponse>> GetSessions()
        {
            IEnumerable<BlSessionModelResponse> sessions = await _sessionRepository.GetSessions();

            return sessions.Select(Mapper.Map<SessionModelResponse>);
        }


    }
}
