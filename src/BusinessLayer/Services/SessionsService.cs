using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using DalServiceModel = DataAccessLayer.Models.DataTransferObjects.ServiceModel;
using DalSessionModelResponse = DataAccessLayer.Models.DataTransferObjects.SessionModelResponse;
using DalSessionServiceModel = DataAccessLayer.Models.DataTransferObjects.SessionServiceModel;
using DalSessionModelRequest = DataAccessLayer.Models.DataTransferObjects.SessionModelRequest;
using ServiceModel = BusinessLayer.Models.ServiceModel;
using SessionModelRequest = BusinessLayer.Models.SessionModelRequest;
using SessionModelResponse = BusinessLayer.Models.SessionModelResponse;

namespace BusinessLayer.Services
{
    [UsedImplicitly]
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

        public async Task<SessionModelResponse> AddOrUpdateSession(SessionModelRequest session)
        {
            // все удаляем
            _sessionRepository.DeleteServiceFromSession(session.Id);

            // обновляем
            int id = await _sessionRepository.AddOrUpdateSession(Mapper.Map<DalSessionModelRequest>(session));

            // добавляем новые сервисы
            List<DalSessionServiceModel> services = new List<DalSessionServiceModel>();

            foreach (var service in session.Services)
            {
                DalSessionServiceModel sessionService = new DalSessionServiceModel(session.Id, service);

                sessionService.Id = await _sessionRepository.AddServiceToSession(sessionService);

                services.Add(sessionService);
            }

            // что  ?
            throw new NotImplementedException();
        }

        public void DeleteSession(int id)
        {
            _sessionRepository.DeleteSession(id);
        }
    }
}
