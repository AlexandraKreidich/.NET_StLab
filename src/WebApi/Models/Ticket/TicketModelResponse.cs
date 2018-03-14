using System;
using JetBrains.Annotations;

namespace WebApi.Models.Ticket
{
    [UsedImplicitly]
    public class TicketModelResponse
    {
        public int Id { get; set; }

        [NotNull]
        public string FilmName { get; set; }

        public int PlaceId { get; set; }

        public int PlaceNumber { get; set; }

        public int RowNumber { get; set; }

        [NotNull]
        public string PlaceType { get; set; }

        public int HallName { get; set; }

        [NotNull]
        public string CinemaName { get; set; }

        public decimal SumPrice { get; set; }

        [CanBeNull]
        public string Services { get; set; }

        [NotNull]
        public string TicketStatus { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
