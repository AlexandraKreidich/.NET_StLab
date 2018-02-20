using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
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