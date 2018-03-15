using System;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    public class SessionModelRequest
    {
        public int Id { get; }

        public int FilmId { get; }

        public int HallId { get; }

        public DateTimeOffset Date { get; }

        [CanBeNull]
        public int[] ServiceIds { get; }

        public SessionModelRequest
        (
            int id,
            int filmId,
            int hallId,
            DateTimeOffset date,
            [CanBeNull] int[] serviceIds
        )
        {
            Id = id;
            FilmId = filmId;
            HallId = hallId;
            Date = date;
            ServiceIds = serviceIds;
        }
    }
}
