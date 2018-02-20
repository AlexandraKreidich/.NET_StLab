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
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        // GET /services
        [HttpGet]
        public IEnumerable<ServiceModelResponse> Get(){
            List<ServiceModelResponse> services = new List<ServiceModelResponse>();
            return services;
        }

        // PUT /services
        [HttpPost]
        public IActionResult Put(ServiceModelRequest service){
            return StatusCode((int)System.Net.HttpStatusCode.Created);
        }

        // DELETE /services/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id){
            return StatusCode((int)System.Net.HttpStatusCode.Accepted);
        }
    }
}