using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Hall;
using WebApi.Models.Place;
using BlCinemaModel = BusinessLayer.Models.CinemaModel;
using CinemaModel = WebApi.Models.Cinema.CinemaModel;

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
            IEnumerable<FullHallBlModel> halls = await _cinemasService.GetHalls(id);

            if (halls == null)
            {
                NotFound();
            }

            List<HallApiModel> results = new List<HallApiModel>();

            if (halls != null)
            {
                results = halls.Select(hall => new HallApiModel(
                        hall.Id,
                        hall.CinemaId,
                        hall.Name,
                        hall.PlacesBl.Select(Mapper.Map<PlaceApiModel>).ToArray(),
                        hall.HallSchemeBlModels.Select(Mapper.Map<HallSchemeApiModel>).ToArray())
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