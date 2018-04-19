using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class ServiceDalDtoModelResponseForTicket
    {
        public int Id { get; }

        [NotNull]
        public string Name { get; }

        public decimal Price { get; }

        public int Amount { get; }

        public ServiceDalDtoModelResponseForTicket(
            [NotNull] string name,
            decimal price,
            int id,
            int amount
        )
        {
            Id = id;
            Name = name;
            Price = price;
            Amount = amount;
        }
    }
}
