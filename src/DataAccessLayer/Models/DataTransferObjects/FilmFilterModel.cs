using System;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class FilmFilterModel
    {
        [NotNull]
        public string City { get; set; }

        [NotNull]
        public string Cinema { get; set; }

        [NotNull]
        public string Film { get; set; }

        public DateTimeOffset Date { get; set; }

        public int FreePlaces { get; set; }
    }
}
