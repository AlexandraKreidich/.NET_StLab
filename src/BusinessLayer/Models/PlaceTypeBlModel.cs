using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    public class PlaceTypeBlModel
    {
        public int Id { get; }

        [NotNull]
        public string Name { get; }

        public PlaceTypeBlModel
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
