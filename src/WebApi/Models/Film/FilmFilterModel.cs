using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Film
{
    public class FilmFilterModel
    {
        public string City { get; set; }
        public string Cinema { get; set; }
        public string Film { get; set; }
        public DateTimeOffset Date { get; set; }
        public int FreePlaces { get; set; }
    }
}
