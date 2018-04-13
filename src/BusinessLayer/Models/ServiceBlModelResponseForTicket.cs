using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    public class ServiceBlModelResponseForTicket
    {
        public int Id { get; }

        [NotNull]
        public string Name { get; }

        public decimal Price { get; }

        public int Amount { get; }

        public ServiceBlModelResponseForTicket(
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
