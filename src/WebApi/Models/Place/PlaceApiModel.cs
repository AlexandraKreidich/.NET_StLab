using JetBrains.Annotations;

namespace WebApi.Models.Place
{
    [UsedImplicitly]
    public class PlaceApiModel
    {
        public int Id { get; }

        public int HallId { get; }

        [NotNull]
        public PlaceTypeApiModel Type { get; }

        public int RowNumber { get;}

        public int PlaceNumber { get;}

        public PlaceApiModel(
            int id,
            int hallId,
            [NotNull] PlaceTypeApiModel type,
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
