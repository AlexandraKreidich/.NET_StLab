using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FiltersController : Controller
    {
        //filmcontroller
        // POST /filters/search-films
        [HttpPost]
        [Route("search-films")]
        public IEnumerable<FilmModel> SearchFilms([FromBody]FilmFilterModelRequest request)
        {
            List<FilmModel> responseFilms = new List<FilmModel>();
            return responseFilms;
        }
    }
}