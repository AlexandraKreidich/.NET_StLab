using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Service;
using WebApi.Models.Session;
using BlSessionModelResponse = BusinessLayer.Models.SessionModelResponse;
using BlSessionModelRequest = BusinessLayer.Models.SessionModelRequest;
using BlServiceModel = BusinessLayer.Models.ServiceModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SessionsController : Controller
    {
        [NotNull]
        private readonly ISessionsService _sessionService;

        public SessionsController([NotNull] ISessionsService sessionService)
        {
            _sessionService = sessionService;
        }

        // GET /sessions/{id}/services -> + (если нет такого сеанса?)
        [HttpGet]
        [Route("{sessionId}/services")]
        public async Task<IActionResult> GetServices(int sessionId)
        {
            IEnumerable<BlServiceModel> services = await _sessionService.GetServises(sessionId);

            return Ok(
                services.Select(Mapper.Map<ServiceModel>)
            );
        }

        // GET /sessions sp created -> +
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<BlSessionModelResponse> sessions = await _sessionService.GetSessions();

            return Ok(
                sessions.Select(Mapper.Map<SessionModelResponse>)
            );
        }

        // PUT /sessions ?генерация еще нужна цены для каждого места в зале
        [HttpPut]
        public IActionResult Put(SessionModelRequest session)
        {
            _sessionService.AddOrUpdateSession(Mapper.Map<BlSessionModelRequest>(session));

            return StatusCode((int) HttpStatusCode.Created);
        }

        // DELETE /sessions/{id} - при удалении удалятся и билеты и цена
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _sessionService.DeleteSession(id);

            return StatusCode((int)HttpStatusCode.Accepted);
        }
    }
}