using System;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class SessionModelRequest
    {
        public int Id { get; }

        public int FilmId { get; }

        public int HallId { get; }

        public DateTimeOffset Date { get; }

        public SessionModelRequest(
            int id,
            int filmId,
            int hallId,
            DateTimeOffset date
        )
        {
            Id = id;
            FilmId = filmId;
            HallId = hallId;
            Date = date;
        }
    }
}
