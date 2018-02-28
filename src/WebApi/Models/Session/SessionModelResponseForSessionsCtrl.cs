using System;

namespace WebApi.Models.Session
{
    public class SessionModelResponseForSessionsCtrl
    {
        public int SessionId { get; set; }
        public string CityName { get; set; }
        public string CinemaName { get; set; }
        public string HallName { get; set; }
        public string FilmName { get; set; }
        public string FilmId { get; set; }
        public DateTimeOffset Time { get; set; }
        public decimal Price { get; set; }
    }
}
