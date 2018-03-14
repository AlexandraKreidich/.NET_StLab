using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Price;
using WebApi.Models.Service;
using WebApi.Models.Session;
using BlSessionModelResponse = BusinessLayer.Models.SessionModelResponse;
using BlSessionModelRequest = BusinessLayer.Models.SessionModelRequest;
using BlServiceModel = BusinessLayer.Models.ServiceModel;
using BlPriceRequestForSessionsController = BusinessLayer.Models.PriceRequestForSessionController;

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

        // GET /sessions
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<BlSessionModelResponse> sessions = await _sessionService.GetSessions();

            return Ok(
                sessions.Select(Mapper.Map<SessionModelResponse>)
            );
        }

        // GET /sessions/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            BlSessionModelResponse session = await _sessionService.GetSessionById(id);

            if (session == null)
            {
                return NotFound();
            }

            return Ok(
                Mapper.Map<BlSessionModelResponse>(session)
                );
        }

        // GET /sessions/{id}/services
        [HttpGet]
        [Route("{sessionId}/services")]
        public async Task<IActionResult> GetServices(int sessionId)
        {
            IEnumerable<BlServiceModel> services = await _sessionService.GetServices(sessionId);

            if (services == null)
            {
                return NotFound();
            }

            return Ok(
                services.Select(Mapper.Map<ServiceModel>)
            );
        }

        // PUT /sessions
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]SessionModelRequest session)
        {
            BlSessionModelResponse sessionResponse = await _sessionService.AddOrUpdateSession(Mapper.Map<BlSessionModelRequest>(session));

            return Ok(
                Mapper.Map<SessionModelResponse>(sessionResponse)
            );
        }

        // PUT /sessions/{id}/price
        [HttpPut]
        [Route("{id:int}/price")]
        public IActionResult Put(int id, [FromBody] PriceRequestForSessionController price)
        {
            BlPriceRequestForSessionsController priceRequest = new BlPriceRequestForSessionsController(
                price.PlaceId, price.Price, id
            );

            _sessionService.AddOrUpdatePriceForSession(priceRequest);

            return Ok();
        }

        // DELETE /sessions/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _sessionService.DeleteSession(id);

            return Ok();
        }
    }
}