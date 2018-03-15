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

        public DateTime StartRentDate { get;}

        public DateTime EndRentDate { get;}

        public FilmModel(
            int id,
            [NotNull] string name,
            [NotNull] string description,
            DateTime startEndRentDate,
            DateTime endRentDate
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
