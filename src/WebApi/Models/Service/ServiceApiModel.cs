using JetBrains.Annotations;

namespace WebApi.Models.Service
{
    [UsedImplicitly]
    public class ServiceApiModel
    {
        public int Id { get; }

        [NotNull]
        public string Name { get; }

        public decimal Price { get; }

        public ServiceApiModel(
            [NotNull] string name,
            decimal price,
            int id
        )
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
