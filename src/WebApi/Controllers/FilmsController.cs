﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Film;
using WebApi.Models.Session;
using BlFilmModel = BusinessLayer.Models.FilmModel;
using BlFilmFilterModel = BusinessLayer.Models.FilmFilterModel;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FilmsController : Controller
    {
        [NotNull]
        private readonly IFilmsService _filmsService;

        public FilmsController([NotNull] IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }

        // GET /films/now-playing
        [HttpGet("now-playing")]
        public async Task<IActionResult> GetNowPlayingFilms()
        {
            IEnumerable<BlFilmModel> films = await _filmsService.GetNowPlayingFilms();

            return Ok(
                    films.Select(Mapper.Map<FilmModel>)
                );
        }

        // GET /films
        [HttpGet]
        public async Task<IEnumerable<FilmModel>> Get()
        {
            IEnumerable<BlFilmModel> films = await _filmsService.GetFilms();

            return films.Select(Mapper.Map<FilmModel>);
        }

        // GET /films/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            BlFilmModel film = await _filmsService.GetFilmsById(id);

            if (film == null)
            {
                return NotFound();
            }

            return Ok(
                Mapper.Map<FilmModel>(film)
                );
        }

        // GET /films/{id}/sessions
        [HttpGet("{id:int}/sessions")]
        public async Task<IActionResult> GetSessions(int id)
        {
            IEnumerable<BusinessLayer.Models.SessionModelResponse> sessions = await _filmsService.GetSessionsForFilm(id);

            if (sessions == null)
            {
                return NotFound();
            }

            return Ok(
                sessions.Select(Mapper.Map<SessionModelResponse>)
                );
        }

        // POST /films/search-films ??? -> Datetime
        [HttpPost("search-films")]
        public async Task<IActionResult> SearchFilms([NotNull] [FromBody]FilmFilterModel request)
        {
            IEnumerable<BusinessLayer.Models.SessionModelResponse> sessions = await _filmsService.SearchFilms(Mapper.Map<BlFilmFilterModel>(request));

            if (sessions == null)
            {
                return NotFound();
            }

            return Ok(
                sessions.Select(Mapper.Map<SessionModelResponse>)
                );
        }

        // PUT /films ???
        [HttpPut]
        public async Task<IActionResult> Put([NotNull] [FromBody]FilmModel filmToAdd)
        {
            //Mapper.Map<BlFilmModel>(filmToAdd)

            BlFilmModel film = await _filmsService.AddOrUpdateFilm(new BlFilmModel(
                filmToAdd.Id,
                filmToAdd.Name,
                filmToAdd.Description,
                filmToAdd.StartRentDate,
                filmToAdd.EndRentDate
            ));

            return Ok(
                Mapper.Map<FilmModel>(film)
                );
        }
    }
}