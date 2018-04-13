using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class ServiceDalDtoModelRequestForTicket
    {
        public int TicketId { get; }

        public int ServiceId { get; }

        public int Amount { get; }

        public ServiceDalDtoModelRequestForTicket(
            int ticketId,
            int serviceId,
            int amount
        )
        {
            TicketId = ticketId;
            ServiceId = serviceId;
            Amount = amount;
        }
    }
}
