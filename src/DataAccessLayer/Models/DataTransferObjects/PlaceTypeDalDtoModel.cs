using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class PlaceTypeDalDtoModel
    {
        public int Id { get; }

        [NotNull]
        public string Name { get; }

        public PlaceTypeDalDtoModel
        (
            int id,
            [NotNull] string name
        )
        {
            Id = id;
            Name = name;
        }
    }
}
