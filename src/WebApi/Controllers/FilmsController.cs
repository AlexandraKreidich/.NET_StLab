using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Film;
using BlFilmModel = BusinessLayer.Models.FilmModel;
using FilmModel = WebApi.Models.Film.FilmModel;
using SessionModelResponse = WebApi.Models.Session.SessionModelResponse;


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
        [HttpGet]
        [Route("now-playing")]
        public async Task<IActionResult> GetNowPlayingFilms()
        {
            IEnumerable<BlFilmModel> films = await _filmsService.GetNowPlayingFilms();

            return Ok(
                    Mapper.Map<IEnumerable<FilmModel>>(films)
                );
        }

        // GET /films
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<BlFilmModel> films = await _filmsService.GetFilms();

            return Ok(
                Mapper.Map<IEnumerable<FilmModel>>(films)
            );
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

        // GET /films/filters-info
        [HttpGet("filters-info")]
        public async Task<IActionResult> GetFiltersInfo()
        {
            FiltersInfoBlModel filters = await _filmsService.GetFiltersInfo();

            return Ok(
                Mapper.Map<FiltersInfoModel>(filters)
            );
        }

        // POST /films/search-films
        [HttpPost("search-films")]
        public async Task<IActionResult> SearchFilms([NotNull] [FromBody]FilmFilterModel request)
        {
            IEnumerable<BlFilmModel> films =
                await _filmsService.SearchFilms(Mapper.Map<FilmFilterBlModel>(request));

            return Ok(
                films.Select(Mapper.Map<FilmModel>)
                );
        }

        // PUT /films
        [HttpPut]
        public async Task<IActionResult> Put([NotNull] [FromBody]FilmModel filmToAdd)
        {

            BlFilmModel film = await _filmsService.AddOrUpdateFilm(Mapper.Map<BlFilmModel>(filmToAdd));

            return Ok(
                Mapper.Map<FilmModel>(film)
                );
        }
    }
}