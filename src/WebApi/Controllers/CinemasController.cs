using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Hall;
using WebApi.Models.Place;
using WebApi.Models.Cinema;
using BlCinemaModel = BusinessLayer.Models.CinemaModel;
using BlHallModelForApi = BusinessLayer.Models.HallModelForApi;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CinemasController : Controller
    {
        [NotNull]
        private readonly ICinemasService _cinemasService;

        public CinemasController([NotNull] ICinemasService cinemasService)
        {
            _cinemasService = cinemasService;
        }

        // GET /cinemas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<BlCinemaModel> cinemas = await _cinemasService.GetCinemas();

            return Ok(
                cinemas.Select(Mapper.Map<CinemaModel>)
                );
        }

        // GET /cinemas/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            BlCinemaModel cinema = await _cinemasService.GetCinemaById(id);

            if (cinema == null)
            {
                return NotFound();
            }

            return Ok(
                Mapper.Map<CinemaModel>(cinema)
                );
        }

        // GET /cinemas/{id}/halls
        [HttpGet("{id:int}/halls")]
        public async Task<IActionResult> GetHalls(int id)
        {
            IEnumerable<BlHallModelForApi> halls = await _cinemasService.GetHalls(id);

            if (halls == null)
            {
                NotFound();
            }

            List<HallModel> results = new List<HallModel>();

            if (halls != null)
            {
                results = halls.Select(hall => new HallModel(
                        hall.Id,
                        hall.CinemaId,
                        hall.Name,
                        hall.Places.Select(Mapper.Map<PlaceModelForHall>).ToArray(),
                        hall.HallSchemeModels.Select(Mapper.Map<HallSchemeModel>).ToArray())
                    ).ToList();
            }

            return Ok(results);
        }

        // PUT /cinemas -> add or update cinema
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CinemaModel cinema)
        {
            BlCinemaModel cinemaResponse =
                await _cinemasService.AddOrUpdateCinema(Mapper.Map<BlCinemaModel>(cinema));

            return Ok(
                Mapper.Map<CinemaModel>(cinemaResponse)
                );
        }
    }
}