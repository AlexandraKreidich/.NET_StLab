using JetBrains.Annotations;

namespace WebApi.Models.Place
{
    [UsedImplicitly]
    public class PlaceModelForHall
    { 
        public int Id { get; }

        public int HallId { get; }

        [NotNull]
        public string Type { get; }

        public int RowNumber { get;}

        public int PlaceNumber { get;}

        public PlaceModelForHall(
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
