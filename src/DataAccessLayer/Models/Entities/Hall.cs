using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    internal class Hall
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        [NotNull]
        public string Name { get; set; }
    }
}
