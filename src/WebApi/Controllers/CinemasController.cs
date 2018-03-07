using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Place;
using ApiHallModelResponse = WebApi.Models.Hall.HallModel;
using ApiHallSchemeModelResponse = WebApi.Models.Hall.HallSchemeModel;
using ApiCinemaModel = WebApi.Models.Cinema.CinemaModel;
using CinemaModel = BusinessLayer.Models.CinemaModel;

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
            IEnumerable<CinemaModel> cinemas = await _cinemasService.GetCinemas();

            return Ok(
                cinemas.Select(Mapper.Map<ApiCinemaModel>)
                );
        }

        // GET /cinemas/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            CinemaModel cinema = await _cinemasService.GetCinemaById(id);

            if (cinema == null)
            {
                return NotFound();
            }

            return Ok(
                Mapper.Map<ApiCinemaModel>(cinema)
                );
        }

        // GET /cinemas/{id}/halls
        [HttpGet("{id:int}/halls")]
        public async Task<IActionResult> GetHalls(int id)
        {
            IEnumerable<HallModelForApi> halls = await _cinemasService.GetHalls(id);

            if (halls == null)
            {
                NotFound();
            }

            List<ApiHallModelResponse> results = new List<ApiHallModelResponse>();

            if (halls != null)
            {
                results = halls.Select(hall => new ApiHallModelResponse(
                        hall.Id,
                        hall.CinemaId,
                        hall.Name,
                        hall.Places.Select(Mapper.Map<PlaceModelForHall>).ToArray(),
                        hall.HallSchemeModels.Select(Mapper.Map<ApiHallSchemeModelResponse>).ToArray())
                    ).ToList();
            }

            return Ok(results);
        }

        // PUT /cinemas -> add or update cinema
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ApiCinemaModel cinema)
        {
            CinemaModel cinemaResponse =
                await _cinemasService.AddOrUpdateCinema(Mapper.Map<CinemaModel>(cinema));

            return Ok(
                Mapper.Map<ApiCinemaModel>(cinemaResponse)
                );
        }
    }
}