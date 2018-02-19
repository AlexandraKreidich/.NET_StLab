using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
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
        [Route("")]
        public IEnumerable<FilmModelResponse> GetAllFilms()
        {
            List<FilmModelResponse> Films = new List<FilmModelResponse>();
            return Films;
        }

        // GET /films/{name}
        [HttpGet("{name:string}")]
        public IEnumerable<FilmModelResponse> GetFilmsByName([FromQuery]string name)
        {
            List<FilmModelResponse> FilmsByName = new List<FilmModelResponse>();
            return FilmsByName;
        }

        // GET /films/{id}
        [HttpGet("{id:int}")]
        public FilmModelResponse GetFilm(int id)
        {
            FilmModelResponse film = new FilmModelResponse();
            return film;
        }

        // GET /films/{id}/sessions
        [HttpGet("{id:int}/sessions")]
        public IEnumerable<SessionModelResponse> GetSessions(int id)
        {
            List<SessionModelResponse> sessions = new List<SessionModelResponse>();
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

        // PUT /films --> add new film, if refresh(names should be equal)
        [HttpPut]
        public IActionResult Put([FromBody]FilmModelRequest filmToAdd)
        {
            return StatusCode((int)HttpStatusCode.Created);
        }

        // DELETE /films/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromQuery]int id)
        {
            return StatusCode((int)HttpStatusCode.Accepted);
        }
    }
}