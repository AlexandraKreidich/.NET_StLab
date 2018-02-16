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
    public class CinemasController : Controller
    {
        // GET /cinemas
        [HttpGet]
        public IEnumerable<CinemaModelResponse> Get()
        {
            List<CinemaModelResponse> cinemas = new List<CinemaModelResponse>();
            return cinemas;
        }

        // PUT /cinemas
        [HttpPut]
        public IActionResult Put(CinemaModelRequest filmToAdd)
        {
            return StatusCode((int)HttpStatusCode.Created);
        }

        // DELETE /cinemas/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            return StatusCode((int)HttpStatusCode.Accepted);
        }

        /*-----------------------------*/

        // GET /cinemas/{id}/sessions
        /*[HttpGet]
        [Route("{id:int}/sessions")]
        */
    }
}