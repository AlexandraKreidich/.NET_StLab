using System;

namespace WebApi.Models.Film
{
    public class FilmFilterModelRequest
    {
        public string City { get; set; }
        public string Cinema { get; set; }
        public string Film { get; set; }
        public DateTimeOffset Date { get; set; }
        public int FreePlaces { get; set; }
    }
}
