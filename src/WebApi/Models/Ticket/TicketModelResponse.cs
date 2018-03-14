using System;
using System.Collections.Generic;
using Common;
using JetBrains.Annotations;
using WebApi.Models.Service;

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
        public List<ServiceModel> Services { get; set; }

        public TicketStatus TicketStatus { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
