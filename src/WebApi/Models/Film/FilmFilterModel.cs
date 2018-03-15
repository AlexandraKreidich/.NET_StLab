using System;
using JetBrains.Annotations;

namespace WebApi.Models.Film
{
    public class FilmFilterModel
    {
        [CanBeNull]
        public string City { get;}

        [CanBeNull]
        public string Cinema { get;}

        [CanBeNull]
        public string Film { get; }

        [CanBeNull]
        public DateTime? Date { get; }


        public int FreePlaces { get;}

        public FilmFilterModel
        (
            [CanBeNull] string city,
            string cinema,
            string film,
            DateTime date,
            int freePlaces
        )
        {
            City = city;
            Cinema = cinema;
            Film = film;
            Date = date;
            FreePlaces = freePlaces;
        }
    }
}
