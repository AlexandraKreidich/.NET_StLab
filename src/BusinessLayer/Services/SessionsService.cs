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

        public async Task<IEnumerable<ServiceBlModel>> GetServices(int sessionId)
        {
            DalSessionModelResponse session = await _sessionRepository.GetSessionById(sessionId);

            if (session == null)
            {
                return null;
            }

            IEnumerable<DalServiceModel> services = await _sessionRepository.GetServices(sessionId);

            return services.Select(Mapper.Map<ServiceBlModel>);
        }

        public async Task<IEnumerable<SessionModelResponse>> GetSessions()
        {
            IEnumerable<DalSessionModelResponse> sessions = await _sessionRepository.GetSessions();

            return sessions.Select(Mapper.Map<SessionModelResponse>);
        }

        public async Task<SessionModelResponse> GetSessionById(int id)
        {
            DalSessionModelResponse session = await _sessionRepository.GetSessionById(id);

            return Mapper.Map<SessionModelResponse>(session);
        }

        public async Task<SessionModelResponse> AddOrUpdateSession(SessionModelRequest session)
        {
            _sessionRepository.DeleteServiceFromSession(session.Id);

            int id = await _sessionRepository.AddOrUpdateSession(Mapper.Map<DalSessionModelRequest>(session));

            if (session.ServiceIds != null)
            {

                foreach (var service in session.ServiceIds)
                {
                    DalSessionServiceModel sessionService = new DalSessionServiceModel(session.Id, service);

                    _sessionRepository.AddServiceToSession(sessionService);
                }
            }

            return await GetSessionById(session.Id) ?? throw new InvalidOperationException();
        }

        public void AddOrUpdatePriceForSession(PriceBlRequest priceBl)
        {
            int l = priceBl.Prices.Length;

            for (int i = 0; i < l; i++)
            {
                _sessionRepository.AddOrUpdatePriceForSession(priceBl.SessionId, priceBl.PlaceIds[i], priceBl.Prices[i]);
            }
        }

        public void DeleteSession(int id)
        {
            _sessionRepository.DeleteSession(id);
        }
    }
}
