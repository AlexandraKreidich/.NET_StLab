using System;
using JetBrains.Annotations;

namespace WebApi.Models.Session
{
    public class SessionModelResponse
    {
        public int Id { get; set; }

        public int HallId { get; set; }

        [NotNull] 
        public string HallName {get;set;}

        public int FilmId { get; set; }

        [NotNull] 
        public string FilmName { get; set; }

        [NotNull] 
        public string CinemaName { get; set; }

        [NotNull] 
        public string CinemaCity { get; set; }

        public DateTimeOffset SessionDate { get; set; }

        public SessionModelResponse(
            int id,
            int hallId,
            [NotNull] string hallName,
            int filmId,
            [NotNull] string filmName,
            [NotNull] string cinemaName,
            [NotNull] string cinemaCity,
            DateTimeOffset sessionDate
        )
        {
            Id = id;
            HallId = hallId;
            HallName = hallName;
            FilmId = filmId;
            FilmName = filmName;
            CinemaCity = cinemaCity;
            CinemaName = cinemaName;
            SessionDate = sessionDate;
        }
    }
}
