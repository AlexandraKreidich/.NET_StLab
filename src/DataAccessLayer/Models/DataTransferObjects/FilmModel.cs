using System;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class FilmModel
    {
        public int Id { get;}

        [NotNull]
        public string Name { get;}

        [NotNull]
        public string Description { get;}

        public DateTimeOffset StartRentDate { get;}

        public DateTimeOffset EndRentDate { get;}

        public FilmModel(
            int id,
            [NotNull] string name,
            [NotNull] string description,
            DateTimeOffset startEndRentDate,
            DateTimeOffset endRentDate
        )
        {
            Id = id;
            Name = name;
            Description = description;
            StartRentDate = startEndRentDate;
            EndRentDate = endRentDate;
        }
    }
}
