using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    public class ServiceBlModelRequestForTicket
    {
        public int Id { get; }

        public int Amount { get; }

        public ServiceBlModelRequestForTicket(
            int id,
            int amount
        )
        {
            Id = id;
            Amount = amount;
        }
    }
}
