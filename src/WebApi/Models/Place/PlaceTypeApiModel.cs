using JetBrains.Annotations;

namespace WebApi.Models.Place
{
    [UsedImplicitly]
    public class PlaceTypeApiModel
    {
        public int Id { get; }

        [NotNull]
        public string Name { get; }

        public PlaceTypeApiModel
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
