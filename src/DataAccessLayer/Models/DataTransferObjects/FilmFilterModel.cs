﻿using System;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class FilmFilterModel
    {
        [NotNull]
        public string City { get; set; }

        [NotNull]
        public string Cinema { get; set; }

        [NotNull]
        public string Film { get; set; }

        [CanBeNull]
        public DateTime? Date { get; set; }

        public int FreePlaces { get; set; }
    }
}
