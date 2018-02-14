using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/films")]
    public class FilmsController : Controller
    {
        // GET /films/now-playing
        [HttpGet]
        [Route("now-playing")]
        public IEnumerable<FilmModel> NowPlayingFilms()
        {
            List<FilmModel> nowPlayingFilms = new List<FilmModel>();
            return nowPlayingFilms;
        }

        // GET /films
        [HttpGet]
        [Route("")]
        public IEnumerable<FilmModel> AllFilms()
        {
            List<FilmModel> nowPlayingFilms = new List<FilmModel>();
            return nowPlayingFilms;
        }

        // POST /films/{name}
        [HttpPost("{name:string}")]
        public IEnumerable<FilmModel> FilmsByName([FromBody]string name)
        {
            List<FilmModel> nowPlayingFilms = new List<FilmModel>();
            return nowPlayingFilms;
        }

        // POST /films/add
        [HttpPost("add")]
        public IActionResult AddFilm([FromBody]FilmModel filmToAdd)
        {
            return null;
        }

        // PUT /films/update
        [HttpPut("update")]
        public IActionResult UpdateFilm([FromBody]FilmModel filmToUpdate)
        {
            return null;
        }

        // DELETE /films/{id}
        [HttpDelete("{id:int}")]
        public IActionResult DeleteFilm([FromBody]int id)
        {
            return null;
        }
    }
}