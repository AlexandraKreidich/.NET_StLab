using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Film;
using WebApi.Models.Session;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FilmsController : Controller
    {
        // GET /films/now-playing
        [HttpGet]
        [Route("now-playing")]
        public IEnumerable<FilmModelResponse> GetNowPlayingFilms()
        {
            List<FilmModelResponse> nowPlayingFilms = new List<FilmModelResponse>();
            return nowPlayingFilms;
        }

        // GET /films
        [HttpGet]
        public IEnumerable<FilmModelResponse> Get()
        {
            List<FilmModelResponse> films = new List<FilmModelResponse>();
            return films;
        }

        // GET /films/{id}
        [HttpGet("{id:int}")]
        public FilmModelResponse Get(int id)
        {
            FilmModelResponse film = new FilmModelResponse();
            return film;
        }

        // GET /films/{id}/sessions
        [HttpGet("{id:int}/sessions")]
        public IEnumerable<SessionModelResponseForFilmApi> GetSessions(int id)
        {
            List<SessionModelResponseForFilmApi> sessions = new List<SessionModelResponseForFilmApi>();
            return sessions;
        }

        // POST /films/search-films
        [HttpPost]
        [Route("search-films")]
        public IEnumerable<FilmModelResponse> SearchFilms([FromBody]FilmFilterModelRequest request)
        {
            List<FilmModelResponse> responseFilms = new List<FilmModelResponse>();
            return responseFilms;
        }

        //POST /films/{id}/add-service
        [HttpPost]
        [Route("{id:int}/add-service")]
        public IActionResult AddService([FromBody] int serviceId){
            return StatusCode((int)HttpStatusCode.Created);
        }

        // PUT /films --> add or update film
        [HttpPut]
        public IActionResult Put([FromBody]FilmModelRequest filmToAdd)
        {
            return StatusCode((int)HttpStatusCode.Created);
        }

        // DELETE /films/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return StatusCode((int)HttpStatusCode.Accepted);
        }
    }
}