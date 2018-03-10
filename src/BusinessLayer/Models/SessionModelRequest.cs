using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class SessionModelRequest
    {
        public int Id { get; set; }

        public int FilmId { get; set; }

        public int HallId { get; set; }

        public DateTimeOffset Time { get; set; }

        public int[] SessionId { get; set; }
    }
}
