using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Hall;
using BlCinemaModelResponse = BusinessLayer.Models.CinemaModelResponse;
using BlCinemaModelRequest = BusinessLayer.Models.CinemaModelRequest;
using ApiCinemaModelResponse = WebApi.Models.Cinema.CinemaModelResponse;
using ApiCinemaModelRequest = WebApi.Models.Cinema.CinemaModelRequest;

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

        // GET /cinemas +
        [HttpGet]
        public async Task<IEnumerable<ApiCinemaModelResponse>> Get()
        {
            IEnumerable<BlCinemaModelResponse> cinemas = await _cinemasService.GetCinemas();

            return cinemas.Select(Mapper.Map<ApiCinemaModelResponse>);
        }

        // GET /cinemas/{id} +
        [HttpGet("{id:int}")]
        public async Task<ApiCinemaModelResponse> Get(int id)
        {
            BlCinemaModelResponse cinema = await _cinemasService.GetCinemaById(id);

            if (cinema == null)
                return null;

            return Mapper.Map<ApiCinemaModelResponse>(cinema);
        }

        // GET /cinemas/{id}/halls
        [HttpGet("{id:int}/halls")]
        public IEnumerable<HallModel> GetHalls(){
            List<HallModel> halls = new List<HallModel>();
            return halls;
        }

        // PUT /cinemas +
        [HttpPut]
        public async Task<ApiCinemaModelResponse> Put([FromBody]ApiCinemaModelRequest cinema)
        {
            BlCinemaModelRequest cinemaRequest = new BlCinemaModelRequest(cinema.Name, cinema.City);

            BlCinemaModelResponse cinemaResponse = await _cinemasService.AddCinema(cinemaRequest);

            return Mapper.Map<ApiCinemaModelResponse>(cinemaResponse);
        }

        // DELETE /cinemas/{id} +
        [HttpDelete("{id:int}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            return await _cinemasService.DeleteCinema(id);
        }
    }
}