using System;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    public class FilmFilterModel
    {
        [CanBeNull]
        public string City { get; set; }

        [CanBeNull]
        public string Cinema { get; set; }

        [CanBeNull]
        public string Film { get; set; }

        [CanBeNull]
        public DateTime? Date { get; set; }

        public int FreePlaces { get; set; }
    }
}