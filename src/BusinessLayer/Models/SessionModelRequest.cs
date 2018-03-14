using System;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    public class SessionModelRequest
    {
        public int Id { get; set; }

        public int FilmId { get; set; }

        public int HallId { get; set; }

        public DateTimeOffset Time { get; set; }

        [CanBeNull]
        public int[] Services { get; set; }
    }
}
