using System;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class FilmFilterModel
    {
        [CanBeNull] 
        public string City { get; set; }

        [CanBeNull] 
        public string Cinema { get; set; }

        [CanBeNull] 
        public string Film { get; set; }

        public DateTime? Date { get; set; }

        public int FreePlaces { get; set; }
    }
}