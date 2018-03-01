using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    internal class Place
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        [NotNull]
        public string PlaceType { get; set; }
        public int PlaceNumber { get; set; }
        public int RowNumber { get; set; }
    }
}
