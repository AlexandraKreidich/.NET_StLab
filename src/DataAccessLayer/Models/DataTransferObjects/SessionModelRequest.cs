using System;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class SessionModelRequest
    {
        public int Id { get; set; }

        public int FilmId { get; set; }

        public int HallId { get; set; }

        public DateTimeOffset Time { get; set; }

        public SessionModelRequest(
            int id,
            int filmId,
            int hallId,
            DateTimeOffset time
        )
        {
            Id = id;
            FilmId = filmId;
            HallId = hallId;
            Time = time;
        }
    }
}
