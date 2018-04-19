using System;
using Common;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class TicketDalDtoModelResponse
    {
        public int TicketId { get; }

        [NotNull]
        public string FilmName { get; }

        public int PlaceNumber { get; }

        public int RowNumber { get; }

        [NotNull]
        public string PlaceType { get; }

        public int PlaceTypeId { get; }

        [NotNull]
        public string HallName { get; }

        [NotNull]
        public string CinemaName { get; }

        public TicketStatus TicketStatus { get; }

        public DateTimeOffset CreatedAt { get; }

        public decimal SessionPrice { get; }

        public TicketDalDtoModelResponse
        (
            int ticketId,
            [NotNull] string filmName,
            int placeNumber,
            int rowNumber,
            [NotNull] string placeType,
            int placeTypeId,
            [NotNull] string hallName,
            [NotNull] string cinemaName,
            TicketStatus ticketStatus,
            DateTimeOffset createdAt,
            decimal sessionPrice
        )
        {
            TicketId = ticketId;
            FilmName = filmName;
            PlaceNumber = placeNumber;
            RowNumber = rowNumber;
            PlaceType = placeType;
            PlaceTypeId = placeTypeId;
            HallName = hallName;
            CinemaName = cinemaName;
            TicketStatus = ticketStatus;
            CreatedAt = createdAt;
            SessionPrice = sessionPrice;
        }
    }
}
