using System;

namespace WebApi.Models.Session
{
    public class SessionModelResponseForFilmApi
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        public int FilmId { get; set; }
        public string CinemaName { get; set; }
        public string CinemaCity { get; set; }
        public DateTimeOffset SessionDate { get; set; }
    }
}
