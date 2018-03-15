using System;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class TicketInfoModel
    {
        public int TicketId { get; set; }

        [NotNull]
        public string FilmName { get; set; }

        public int PlaceId { get; set; }

        public int PlaceNumber { get; set; }

        public int RowNumber { get; set; }

        [NotNull]
        public string PlaceType { get; set; }

        [NotNull]
        public string HallName { get; set; }

        [NotNull]
        public string CinemaName { get; set; }

        [NotNull]
        public string TicketStatus { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public decimal SessionPrice { get; set; }
    }
}
