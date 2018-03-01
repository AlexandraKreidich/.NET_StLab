using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    [UsedImplicitly]
    internal class Cinema
    {
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        [NotNull]
        public string City { get; set; }

        public int HallsNumber { get; set; }

    }
}
