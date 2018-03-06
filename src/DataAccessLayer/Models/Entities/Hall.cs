using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    [UsedImplicitly]
    internal class Hall
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        [NotNull]
        public string Name { get; set; }
    }
}
