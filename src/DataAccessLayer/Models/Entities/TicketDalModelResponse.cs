using System;
using Common;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    [UsedImplicitly]
    internal class TicketDalModelResponse
    {
        public int TicketId { get; set; }

        [NotNull]
        public string FilmName { get; set; }

        public int PlaceNumber { get; set; }

        public int RowNumber { get; set; }

        [NotNull]
        public string PlaceType { get; set; }

        public int PlaceTypeId { get; set; }

        [NotNull]
        public string HallName { get; set; }

        [NotNull]
        public string CinemaName { get; set; }

        public TicketStatus TicketStatus { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public decimal SessionPrice { get; set; }

    }
}
