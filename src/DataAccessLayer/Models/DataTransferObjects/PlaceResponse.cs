using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class PlaceResponse
    {
        public int Id { get;}
        public int HallId { get;}
        [NotNull]
        public string PlaceType { get;}
        public int PlaceNumber { get;}
        public int RowNumber { get;}

        public PlaceResponse(
            int id,
            int hallId,
            [NotNull] string placeType,
            int placeNumber,
            int rowNumber
        )
        {
            Id = id;
            HallId = hallId;
            PlaceType = placeType;
            PlaceNumber = placeNumber;
            RowNumber = rowNumber;
        }
    }
}
