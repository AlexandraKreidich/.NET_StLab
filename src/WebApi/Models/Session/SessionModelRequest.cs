using System;

namespace WebApi.Models.Session
{
    public class SessionModelRequest
    {
        public int FilmId { get; set; }
        public int HallId { get; set; }
        public DateTimeOffset Time { get; set; }
        public decimal Price { get; set; }
    }
}
