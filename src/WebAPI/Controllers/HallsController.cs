using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Hall;
using WebApi.Models.Place;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class HallsController : Controller
    {
        // GET /halls/{id}/scheme
        [HttpGet]
        [Route("{id:int}/scheme")]
        public IEnumerable<HallSchemeModel> GetScheme(int id)
        {
            List<HallSchemeModel> scheme = new List<HallSchemeModel>();
            return scheme;
        }

        // GET /halls/{id}/places
        [HttpGet]
        [Route("{id:int}/places")]
        public IEnumerable<PlaceModelResponse> Get(int id)
        {
            List<PlaceModelResponse> places = new List<PlaceModelResponse>();
            return places;
        }

        // PUT /halls
        [HttpPut]
        public IActionResult Put([FromBody]HallModel hall)
        {
            return StatusCode((int)HttpStatusCode.Created);
        }

        // DELETE /halls/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            return StatusCode((int)HttpStatusCode.Accepted);
        }
    }
}