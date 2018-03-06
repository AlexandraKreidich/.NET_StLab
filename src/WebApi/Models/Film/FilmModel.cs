using System;

namespace WebApi.Models.Film
{
    public class FilmModel
    {
        public int Id { get; set; }
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected DateTimeOffset StartRentDate { get; set; }
        protected DateTimeOffset EndRentDate { get; set; }
    }
}
