using System;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    internal class SessionResponse
    {
        public int Id { get; set; }

        public int HallId { get; set; }

        [NotNull]
        public string HallName { get; set; }

        public int FilmId { get; set; }

        [NotNull] 
        public string FilmName { get; set; }

        [NotNull] 
        public string CinemaName { get; set; }

        [NotNull] 
        public string CinemaCity { get; set; }

        public DateTimeOffset SessionDate { get; set; }
    }
}
