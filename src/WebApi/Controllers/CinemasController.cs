using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Cinema;
using WebApi.Models.Hall;
using BlCinemaModelResponse = BusinessLayer.Models.CinemaModelResponse;
using BlCinemaModelRequest = BusinessLayer.Models.CinemaModelRequest;
using ApiCinemaModelResponse = WebApi.Models.Cinema.CinemaModelResponse;
using ApiCinemaModelRequest = WebApi.Models.Cinema.CinemaModelResponse;

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
        public IEnumerable<ApiCinemaModelResponse> Get()
        {
            IEnumerable<BlCinemaModelResponse> cinemas = _cinemasService.GetCinemas();

            return cinemas.Select(Mapper.Map<ApiCinemaModelResponse>);
        }

        // GET /cinemas/{id}
        [HttpGet("{id:int}")]
        public ApiCinemaModelResponse Get(int id)
        {
            BlCinemaModelResponse cinema = _cinemasService.GetCinemaById(id);

            return Mapper.Map<ApiCinemaModelResponse>(cinema);
        }

        // GET /cinemas/{id}/halls
        [HttpGet]
        public IEnumerable<HallModel> GetHalls(){
            List<HallModel> halls = new List<HallModel>();
            return halls;
        }

        // PUT /cinemas
        [HttpPut]
        public ApiCinemaModelResponse Put([FromBody]ApiCinemaModelRequest cinema)
        {
            BlCinemaModelRequest cinemaRequest = new BlCinemaModelRequest(cinema.Name, cinema.City);

            BlCinemaModelResponse cinemaResponse = _cinemasService.AddCinema(cinemaRequest);

            return Mapper.Map<ApiCinemaModelResponse>(cinemaResponse);
        }

        // DELETE /cinemas/{id}
        [HttpDelete]
        public HttpStatusCode Delete(int id)
        {
            if (_cinemasService.DeleteCinema(id) == HttpStatusCode.Accepted)
            {
                return HttpStatusCode.Accepted;
            }

            return HttpStatusCode.BadRequest;
        }
    }
}