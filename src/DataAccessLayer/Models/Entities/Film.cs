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

        public DateTime StartRentDate { get; set; }

        public DateTime EndRentDate { get; set; }
    }
}
