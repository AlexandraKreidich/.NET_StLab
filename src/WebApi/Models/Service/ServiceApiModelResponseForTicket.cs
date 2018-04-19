using JetBrains.Annotations;

namespace WebApi.Models.Service
{
    [UsedImplicitly]
    public class ServiceApiModelResponseForTicket
    {
        public int Id { get; }

        [NotNull]
        public string Name { get; }

        public decimal Price { get; }

        public int Amount { get; }

        public ServiceApiModelResponseForTicket(
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
