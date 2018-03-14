using System;
using JetBrains.Annotations;

namespace WebApi.Models.Session
{
    [UsedImplicitly]
    public class SessionModelResponse
    {
        public int Id { get;}

        public int HallId { get;}

        [NotNull]
        public string HallName {get;}

        public int FilmId { get;}

        [NotNull]
        public string FilmName { get;}

        [NotNull]
        public string CinemaName { get;}

        [NotNull]
        public string CinemaCity { get;}

        public DateTimeOffset SessionDate { get;}

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
