using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using ApiFilmModel = WebApi.Models.Film.FilmModel;
using BlFilmModel = BusinessLayer.Models.FilmModel;
using ApiSessionModelResponseForFilmsCtrl = WebApi.Models.Session.SessionModelResponseForFilmsCtrl;
using BlSessionModelResponseForFilmsCtrl = BusinessLayer.Models.SessionModelResponseForFilmsCtrl;
using BlFilmFilterModel = BusinessLayer.Models.FilmFilterModel;
using ApiFilmFilterModel = WebApi.Models.Film.FilmFilterModel;


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

        // GET /films/now-playing +
        [HttpGet("now-playing")]
        public async Task<IActionResult> GetNowPlayingFilms()
        {
            IEnumerable<BlFilmModel> films = await _filmsService.GetNowPlayingFilms();

            return Ok(
                    films.Select(Mapper.Map<ApiFilmModel>)
                );
        }

        // GET /films +
        [HttpGet]
        public async Task<IEnumerable<ApiFilmModel>> Get()
        {
            IEnumerable<BlFilmModel> films = await _filmsService.GetFilms();

            return films.Select(Mapper.Map<ApiFilmModel>);
        }

        // GET /films/{id} +
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            BlFilmModel film = await _filmsService.GetFilmsById(id);

            if (film == null)
            {
                return NotFound();
            }

            return Ok(
                Mapper.Map<ApiFilmModel>(film)
                );
        }

        // GET /films/{id}/sessions +
        [HttpGet("{id:int}/sessions")]
        public async Task<IActionResult> GetSessions(int id)
        {
            IEnumerable<BlSessionModelResponseForFilmsCtrl> sessions = await _filmsService.GetSessionsForFilm(id);

            if (sessions == null)
            {
                return NotFound();
            }

            return Ok(
                sessions.Select(Mapper.Map<ApiSessionModelResponseForFilmsCtrl>)
                );
        }

        // POST /films/search-films +
        [HttpPost]
        [Route("search-films")]
        public async Task<IActionResult> SearchFilms([NotNull] [FromBody]ApiFilmFilterModel request)
        {
            IEnumerable<BlSessionModelResponseForFilmsCtrl> sessions = await _filmsService.SearchFilms(Mapper.Map<BlFilmFilterModel>(request));

            if (sessions == null)
            {
                return NotFound();
            }

            return Ok(
                sessions.Select(Mapper.Map<ApiSessionModelResponseForFilmsCtrl>)
                );
        }

        // PUT /films --> add or update film
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ApiFilmModel filmToAdd)
        {
            BlFilmModel film = await _filmsService.AddOrUpdateFilm(Mapper.Map<BlFilmModel>(filmToAdd));

            return Ok(
                Mapper.Map<ApiFilmModel>(film)
                );
        }
    }
}