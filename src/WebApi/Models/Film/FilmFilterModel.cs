using System;

namespace WebApi.Models.Film
{
    public class FilmFilterModel
    {
        public string City { get; set; }
        public string Cinema { get; set; }
        public string Film { get; set; }
        public DateTime Date { get; set; }
        public int FreePlaces { get; set; }
    }
}
