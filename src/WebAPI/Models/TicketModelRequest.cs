using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TicketModelRequest
    {
        public int PlaceId { get; set; }
        public List<String> Services { get; set; }
        public float ServicesPrice { get; set; }
    }
}
