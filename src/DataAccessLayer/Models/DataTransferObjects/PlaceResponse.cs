using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class PlaceResponse
    {
        public int Id { get;}
        public int HallId { get;}
        [NotNull]
        public string Type { get;}
        public int PlaceNumber { get;}
        public int RowNumber { get;}

        public PlaceResponse(
            int id,
            int hallId,
            [NotNull] string type,
            int placeNumber,
            int rowNumber
        )
        {
            Id = id;
            HallId = hallId;
            Type = type;
            PlaceNumber = placeNumber;
            RowNumber = rowNumber;
        }
    }
}
