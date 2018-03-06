﻿using JetBrains.Annotations;

namespace WebApi.Models.Place
{
    [UsedImplicitly]
    public class Place
    {
        public int Id { get; set; }

        public int HallId { get; set; }

        [NotNull]
        public string Type { get; set; }

        public int RowNumber { get; set; }

        public int PlaceNumber { get; set; }

        public Place(
            int id,
            int hallId,
            [NotNull] string type,
            int rowNumber,
            int placeNumber
        )
        {
            Id = id;
            HallId = hallId;
            Type = type;
            RowNumber = rowNumber;
            PlaceNumber = placeNumber;
        }
    }
}
