using System.Net;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class HallsController : Controller
    {
        [NotNull]
        private readonly IHallsService _hallsService;

        public HallsController([NotNull] IHallsService hallsService)
        {
            _hallsService = hallsService;
        }

        // GET /halls/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            HallModelForApi hall = await _hallsService.GetHall(id);

            if (hall == null)
            {
                return NotFound();
            }

            return Ok(hall);
        }

        // PUT /halls
        [HttpPut]
        public IActionResult Put(/*[FromBody]HallModel hall*/)
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