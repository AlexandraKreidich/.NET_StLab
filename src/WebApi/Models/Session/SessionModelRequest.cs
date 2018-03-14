using System;
using JetBrains.Annotations;

namespace WebApi.Models.Session
{
    public class SessionModelRequest
    {
        public int Id { get; }

        public int FilmId { get;}

        public int HallId { get;}

        public DateTimeOffset Date { get;}

        [CanBeNull]
        public int[] Services { get;}

        public SessionModelRequest
        (
            int id,
            int filmId,
            int hallId,
            DateTimeOffset date,
            int[] services
        )
        {
            Id = id;
            FilmId = filmId;
            HallId = hallId;
            Date = date;
            Services = services;
        }
    }
}