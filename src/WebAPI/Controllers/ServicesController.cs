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
    [Route("api/Services")]
    public class ServicesController : Controller
    {
        // POST /services/{session-id}
        [HttpPost("{id:int}")]
        public IEnumerable<ServiceModel> GetServicesForSessionId([FromBody]int id)
        {
            List<ServiceModel> services = new List<ServiceModel>();
            return services;
        }
    }
}