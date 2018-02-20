using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SessionModelRequest
    {
        public int FilmId { get; set; }
        public int HallId { get; set; }
        public DateTimeOffset Time { get; set; }
        public float Price { get; set; }
    }
}
