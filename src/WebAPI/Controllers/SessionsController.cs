using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Service;
using WebApi.Models.Session;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SessionsController : Controller
    {
        // GET /sessions/{id}/services
        [HttpGet("{id:int}/services")]
        public IEnumerable<ServiceModelResponse> GetServices([FromBody]int id)
        {
            List<ServiceModelResponse> services = new List<ServiceModelResponse>();
            return services;
        }

        // GET /sessions
        [HttpGet]
        public IEnumerable<SessionModelResponseForSessionsCtrl> Get()
        {
            List<SessionModelResponseForSessionsCtrl> sessions = new List<SessionModelResponseForSessionsCtrl>();
            return sessions;
        }

        // DELETE /sessions/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return StatusCode((int)HttpStatusCode.Accepted);
        }

        // PUT /sessions
        [HttpPut]
        public IActionResult Put(SessionModelRequest session)
        {
            return StatusCode((int) HttpStatusCode.Created);
        }
    }
}