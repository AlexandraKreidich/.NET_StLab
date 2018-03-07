using System;
using JetBrains.Annotations;

namespace WebApi.Models.Session
{
    public class SessionModelResponseForSessionsCtrl
    {
        public int SessionId { get; set; }

        [NotNull] 
        public string CityName { get; set; }

        [NotNull] 
        public string CinemaName { get; set; }

        [NotNull] 
        public string HallName { get; set; }

        [NotNull] 
        public string FilmName { get; set; }

        public int FilmId { get; set; }

        public DateTimeOffset Time { get; set; }

        public decimal Price { get; set; }
    }
}
