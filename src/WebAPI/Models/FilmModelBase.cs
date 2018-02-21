using System;

namespace WebAPI.Models
{
    public class FilmModelBase
    {
        public int Id { get; set; }
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected DateTimeOffset StartRentDate { get; set; }
        protected DateTimeOffset EndRentDate { get; set; }
    }
}
