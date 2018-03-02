using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Place;
using BlCinemaModelResponse = BusinessLayer.Models.CinemaModelResponse;
using BlCinemaModelRequest = BusinessLayer.Models.CinemaModelRequest;
using ApiCinemaModelResponse = WebApi.Models.Cinema.CinemaModelResponse;
using ApiCinemaModelRequest = WebApi.Models.Cinema.CinemaModelRequest;
using BlHallModelResponse = BusinessLayer.Models.HallModelResponse;
using ApiHallModelResponse = WebApi.Models.Hall.HallModelResponse;
using BlHallSchemeModelResponse = BusinessLayer.Models.HallSchemeModelResponse;
using ApiHallSchemeModelResponse = WebApi.Models.Hall.HallSchemeModelResponse;

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
            IEnumerable<BlCinemaModelResponse> cinemas = await _cinemasService.GetCinemas();

            return Ok(
                cinemas.Select(Mapper.Map<ApiCinemaModelResponse>)
                );
        }

        // GET /cinemas/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            BlCinemaModelResponse cinema = await _cinemasService.GetCinemaById(id);

            if (cinema == null)
               return BadRequest();

            return Ok(
                Mapper.Map<ApiCinemaModelResponse>(cinema)
                );
        }

        // GET /cinemas/{id}/halls
        [HttpGet("{id:int}/halls")]
        public async Task<IActionResult> GetHalls(int id)
        {
            IEnumerable<BlHallModelResponse> halls = await _cinemasService.GetHalls(id);

            List<ApiHallModelResponse> results =
                halls.Select(hall => new ApiHallModelResponse(
                    hall.Id,
                    hall.CinemaId,
                    hall.Name,
                    hall.Places.Select(Mapper.Map<PlaceModelResponseForHall>).ToArray(),
                    hall.HallSchemeModels.Select(Mapper.Map<ApiHallSchemeModelResponse>).ToArray())
                ).ToList();

            return Ok(results);
        }

        // PUT /cinemas
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ApiCinemaModelRequest cinema)
        {
            BlCinemaModelRequest cinemaRequest = new BlCinemaModelRequest(cinema.Name, cinema.City);

            BlCinemaModelResponse cinemaResponse = await _cinemasService.AddCinema(cinemaRequest);

            return Ok(
                Mapper.Map<ApiCinemaModelResponse>(cinemaResponse)
                );
        }
    }
}