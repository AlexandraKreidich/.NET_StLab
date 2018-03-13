using System;

namespace WebApi.Models.Session
{
    public class SessionModelRequest
    {
        public int Id { get; set; }

        public int FilmId { get; set; }

        public int HallId { get; set; }

        public DateTimeOffset Date { get; set; }

        public int[] SessionId { get; set; }
    }
}