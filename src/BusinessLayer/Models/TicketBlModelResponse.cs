using System;
using Common;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    public class TicketBlModelResponse
    {
        public int TicketId { get; }

        [NotNull]
        public string FilmName { get; }

        public int PlaceNumber { get; }

        public int RowNumber { get; }

        [NotNull]
        public PlaceTypeBlModel PlaceType { get; }

        [NotNull]
        public string HallName { get; }

        [NotNull]
        public string CinemaName { get; }

        public decimal SessionPrice { get; }

        [CanBeNull]
        public ServiceBlModel[] Services { get; }

        public TicketStatus TicketStatus { get; }

        public DateTimeOffset CreatedAt { get; }

        public TicketBlModelResponse
        (
            int ticketId,
            [NotNull] string filmName,
            int placeNumber,
            int rowNumber,
            [NotNull] PlaceTypeBlModel placeType,
            [NotNull] string hallName,
            [NotNull] string cinemaName,
            decimal sessionPrice,
            [CanBeNull] ServiceBlModel[] services,
            TicketStatus ticketStatus,
            DateTimeOffset createdAt
        )
        {
            TicketId = ticketId;
            FilmName = filmName;
            PlaceNumber = placeNumber;
            RowNumber = rowNumber;
            PlaceType = placeType;
            HallName = hallName;
            CinemaName = cinemaName;
            SessionPrice = sessionPrice;
            Services = services;
            TicketStatus = ticketStatus;
            CreatedAt = createdAt;
        }
    }
}
