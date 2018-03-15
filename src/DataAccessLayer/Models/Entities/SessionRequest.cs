using System;

namespace DataAccessLayer.Models.Entities
{
    internal class SessionModelRequest
    {
        public int Id { get; set; }

        public int FilmId { get; set; }

        public int HallId { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
