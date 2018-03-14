using System;
using JetBrains.Annotations;

namespace WebApi.Models.Film
{
    public class FilmModel
    {
        public int Id { get;}

        [NotNull]
        public string Name { get;}

        [NotNull]
        public string Description { get;}

        public DateTime StartRentDate { get;}

        public DateTime EndRentDate { get;}

        public FilmModel(
            int id,
            [NotNull] string name,
            [NotNull] string description,
            DateTime startRentDate,
            DateTime endRentDate
        )
        {
            Id = id;
            Name = name;
            Description = description;
            StartRentDate = startRentDate;
            EndRentDate = endRentDate;
        }
    }
}
