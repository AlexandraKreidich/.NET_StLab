using System;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    internal class Film
    {
        public int Id { get; set; }

        [NotNull] 
        protected string Name { get; set; }

        [NotNull] 
        protected string Description { get; set; }

        protected DateTimeOffset StartRentDate { get; set; }

        protected DateTimeOffset EndRentDate { get; set; }
    }
}
