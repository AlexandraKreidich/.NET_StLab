using System;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    internal class SessionResponseForFilmsCtrl
    {
        public int Id { get; set; }

        public int HallId { get; set; }

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
