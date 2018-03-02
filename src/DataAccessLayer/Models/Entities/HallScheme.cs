﻿using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    [UsedImplicitly]
    internal class HallScheme
    {

        public int Id { get; set; }

        public int HallId { get; set; }

        public int RowNumber { get; set; }

        public int PlacesCount { get; set; }
    }
}
