using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Sessions")]
    public class SessionsController : Controller
    {
        // GET /sessions/{id}/services
        [HttpGet("{id:int}")]
        public IEnumerable<ServiceModel> Get([FromBody]int id)
        {
            List<ServiceModel> services = new List<ServiceModel>();
            return services;
        }

        // GET /sessions
        // DELETE /sessions/{session-id}
        // POST /sessions/add
        // PUT /sessions/update
    }
}