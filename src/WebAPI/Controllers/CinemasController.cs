using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.Cinema;
using WebAPI.Models.Hall;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CinemasController : Controller
    {
        // GET /cinemas
        [HttpGet]
        public IEnumerable<CinemaModelResponse> Get()
        {
            //User.FindFirst(ClaimTypes.NameIdentifier);
            List<CinemaModelResponse> cinemas = new List<CinemaModelResponse>();
            return cinemas;
        }

        // GET /cinemas/{id}
        [HttpGet("{id:int}")]
        public CinemaModelResponse Get(int id)
        {
            var cinema = new CinemaModelResponse();
            return cinema;
        }

        // GET /cinemas/{id}/halls
        [HttpGet]
        public IEnumerable<HallModel> GetHalls(){
            List<HallModel> halls = new List<HallModel>();
            return halls;
        }

        // PUT /cinemas
        [HttpPut]
        public IActionResult Put([FromBody]CinemaModelRequest cinema)
        {
            return StatusCode((int)HttpStatusCode.Created);
        }

        // DELETE /cinemas/{id}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return StatusCode((int)HttpStatusCode.Accepted);
        }
    }
}