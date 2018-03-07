using System;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    [UsedImplicitly]
    internal class Film
    {
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        [NotNull]
        public string Description { get; set; }

        public DateTimeOffset StartRentDate { get; set; }

        public DateTimeOffset EndRentDate { get; set; }
    }
}
