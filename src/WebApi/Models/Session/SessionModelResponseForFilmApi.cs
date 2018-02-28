using System;

namespace WebApi.Models.Session
{
    public class SessionModelResponseForFilmApi
    {
        public int SessionId { get; set; }
        public string CinemaName { get; set; }
        public string CinemaCity { get; set; }
        public DateTimeOffset SessionTime { get; set; }
    }
}
