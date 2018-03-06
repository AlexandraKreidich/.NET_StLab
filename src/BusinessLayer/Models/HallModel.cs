using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    internal class HallModel
    {
        public int Id { get; set; }

        public int CinemaId { get; set; }

        [NotNull]
        public string Name { get; set; }
    }
}
