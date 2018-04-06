using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Hall;
using WebApi.Models.Place;

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
            FullHallBlModel fullHallBl = await _hallsService.GetHall(id);

            if (fullHallBl == null)
            {
                return NotFound();
            }

            return Ok(new HallApiModel(
                fullHallBl.Id,
                fullHallBl.CinemaId,
                fullHallBl.Name,
                fullHallBl.PlacesBl?.Select(Mapper.Map<PlaceApiModel>).ToArray(),
                fullHallBl.HallSchemeBlModels?.Select(Mapper.Map<HallSchemeApiModel>).ToArray()
            ));
        }
        
        // GET /halls/{hallId}/session/{sessionId}
        [HttpGet]
        [Route("{hallId:int}/session/{sessionId:int}")]
        public async Task<IActionResult> Get(int hallId, int sessionId)
        {
            FullHallBlModel fullHallBl = await _hallsService.GetHallForSession(hallId, sessionId);

            if (fullHallBl == null)
            {
                return NotFound();
            }

            return Ok(new HallApiModel(
                fullHallBl.Id,
                fullHallBl.CinemaId,
                fullHallBl.Name,
                fullHallBl.PlacesBl?.Select(Mapper.Map<PlaceApiModel>).ToArray(),
                fullHallBl.HallSchemeBlModels?.Select(Mapper.Map<HallSchemeApiModel>).ToArray()
            ));
        }

        // PUT /halls
        [HttpPut]
        public async Task<IActionResult> Put([NotNull] [FromBody]HallApiModel hallApi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FullHallBlModel fullHallBlRequest = new FullHallBlModel(
                hallApi.Id,
                hallApi.CinemaId,
                hallApi.Name,
                hallApi.PlacesApi?.Select(Mapper.Map<BusinessLayer.Models.PlaceBlModel>).ToArray(),
                hallApi.HallSchemeApiModels?.Select(Mapper.Map<BusinessLayer.Models.HallSchemeBlModel>).ToArray()
            );

            FullHallBlModel fullHallBl = await _hallsService.AddOrOrUpdateHall(fullHallBlRequest);

            return Ok(fullHallBl);
        }
    }
}