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
            HallModelForApi hall = await _hallsService.GetHall(id);

            if (hall == null)
            {
                return NotFound();
            }

            return Ok(new HallModel(
                hall.Id,
                hall.CinemaId,
                hall.Name,
                hall.Places.Select(Mapper.Map<PlaceModelForHall>).ToArray(),
                hall.HallSchemeModels.Select(Mapper.Map<Models.Hall.HallSchemeModel>).ToArray()
            ));
        }

        // PUT /halls
        [HttpPut]
        public async Task<IActionResult> Put([NotNull] [FromBody]HallModel hall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HallModelForApi hallRequest = new HallModelForApi(
                hall.Id,
                hall.CinemaId,
                hall.Name,
                hall.Places.Select(Mapper.Map<BusinessLayer.Models.PlaceModel>).ToArray(),
                hall.HallSchemeModels.Select(Mapper.Map<BusinessLayer.Models.HallSchemeModel>).ToArray()
            );

            HallModelForApi hallResponse = await _hallsService.AddOrOrUpdateHall(hallRequest);

            return Ok(hallResponse);
        }
    }
}