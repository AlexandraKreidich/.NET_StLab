using System;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class FilmModel
    {
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        [NotNull]
        public string Description { get; set; }

        public DateTimeOffset StartRentDate { get; set; }

        public DateTimeOffset EndRentDate { get; set; }

        //public FilmModel(
        //    int id,
        //    [NotNull] string name,
        //    [NotNull] string description,
        //    DateTimeOffset startEndRentDate,
        //    DateTimeOffset endRentDate
        //)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //    StartRentDate = startEndRentDate;
        //    EndRentDate = endRentDate;
        //}
    }
}
