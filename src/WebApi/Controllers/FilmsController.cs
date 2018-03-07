using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Film;
using ApiFilmModel = WebApi.Models.Film.FilmModel;
using BlFilmModel = BusinessLayer.Models.FilmModel;
using ApiSessionModelResponseForFilmsCtrl = WebApi.Models.Session.SessionModelResponseForFilmsCtrl;
using BlSessionModelResponseForFilmsCtrl = BusinessLayer.Models.SessionModelResponseForFilmsCtrl;

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
        [Route("now-playing")]
        public async Task<IEnumerable<ApiFilmModel>> GetNowPlayingFilms()
        {
            IEnumerable<BlFilmModel> films = await _filmsService.GetNowPlayingFilms();

            return films.Select(Mapper.Map<ApiFilmModel>);
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
        public async Task<ApiFilmModel> Get(int id)
        {
            BlFilmModel film = await _filmsService.GetFilmsById(id);

            return Mapper.Map<ApiFilmModel>(film);
        }

        // GET /films/{id}/sessions +
        [HttpGet("{id:int}/sessions")]
        public async Task<IEnumerable<ApiSessionModelResponseForFilmsCtrl>> GetSessions(int id)
        {
            IEnumerable<BlSessionModelResponseForFilmsCtrl> sessions = await _filmsService.GetSessionsForFilm(id);

            return sessions.Select(Mapper.Map<ApiSessionModelResponseForFilmsCtrl>);
        }

        // POST /films/search-films +
        [HttpPost]
        [Route("search-films")]
        public IEnumerable<ApiFilmModel> SearchFilms([NotNull] [FromBody]FilmFilterModel request)
        {
            List<ApiFilmModel> responseFilms = new List<ApiFilmModel>();
            return responseFilms;
        }

        //POST /films/{id}/add-service -> sessions ctrl
        [HttpPost]
        [Route("{id:int}/add-service")]
        public IActionResult AddService([FromBody] int serviceId){
            return StatusCode((int)HttpStatusCode.Created);
        }

        // PUT /films --> add or update film sp created
        [HttpPut]
        public IActionResult Put([FromBody]ApiFilmModel filmToAdd)
        {
            return StatusCode((int)HttpStatusCode.Created);
        }

        // DELETE /films/{id} sp created
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return StatusCode((int)HttpStatusCode.Accepted);
        }
    }
}