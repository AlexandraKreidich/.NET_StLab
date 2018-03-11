using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using DalServiceModel = DataAccessLayer.Models.DataTransferObjects.ServiceModel;
using DalSessionModelResponse = DataAccessLayer.Models.DataTransferObjects.SessionModelResponse;
using DalSessionServiceModel = DataAccessLayer.Models.DataTransferObjects.SessionServiceModel;
using DalSessionModelRequest = DataAccessLayer.Models.DataTransferObjects.SessionModelRequest;

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
            IEnumerable<DalServiceModel> services = await _sessionRepository.GetServises(sessionId);

            return services.Select(Mapper.Map<ServiceModel>);
        }

        public async Task<IEnumerable<SessionModelResponse>> GetSessions()
        {
            IEnumerable<DalSessionModelResponse> sessions = await _sessionRepository.GetSessions();

            return sessions.Select(Mapper.Map<SessionModelResponse>);
        }

        public Task<SessionModelResponse> AddOrUpdateSession(SessionModelRequest session)
        {
            foreach (var service in session.Services)
            {
                
            }

            throw new NotImplementedException();
        }
    }
}
