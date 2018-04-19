using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    [UsedImplicitly]
    internal class ServiceDalModelResponseForTicket
    {
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}
