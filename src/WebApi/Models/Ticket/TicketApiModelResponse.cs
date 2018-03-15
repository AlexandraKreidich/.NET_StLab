using System;
using Common;
using JetBrains.Annotations;
using WebApi.Models.Place;
using WebApi.Models.Service;

namespace WebApi.Models.Ticket
{
    [UsedImplicitly]
    public class TicketApiModelResponse
    {
        public int TicketId { get; }

        [NotNull]
        public string FilmName { get; }

        public int PlaceNumber { get; }

        public int RowNumber { get; }

        [NotNull]
        public PlaceTypeApiModel PlaceType { get; }

        public int HallName { get; }

        [NotNull]
        public string CinemaName { get; }

        public decimal SessionPrice { get; }

        [CanBeNull]
        public ServiceApiModel[] Services { get; }

        public TicketStatus TicketStatus { get; }

        public DateTimeOffset CreatedAt { get; }

        public TicketApiModelResponse
        (
            int ticketId,
            [NotNull] string filmName,
            int placeNumber,
            int rowNumber,
            [NotNull] PlaceTypeApiModel placeType,
            int hallName,
            [NotNull] string cinemaName,
            decimal sessionPrice,
            [CanBeNull] ServiceApiModel[] services,
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
