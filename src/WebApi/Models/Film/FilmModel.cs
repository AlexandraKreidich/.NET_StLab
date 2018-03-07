using System;
using JetBrains.Annotations;

namespace WebApi.Models.Film
{
    public class FilmModel
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
