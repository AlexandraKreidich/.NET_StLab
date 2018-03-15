using System;
using System.Collections.Generic;
using System.Text;
using Common;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class TicketBlModelRequest
    {
        public int UserId { get; }

        public int PriceId { get; }

        public TicketStatus Status { get; }

        [CanBeNull]
        public int[] Services { get; }

        public TicketBlModelRequest
        (
            int userId,
            int priceId,
            TicketStatus status,
            [CanBeNull] int[] services
        )
        {
            UserId = userId;
            PriceId = priceId;
            Status = status;
            Services = services;
        }
    }
}
