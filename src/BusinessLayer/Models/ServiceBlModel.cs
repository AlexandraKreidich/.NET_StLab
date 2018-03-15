using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class ServiceBlModel
    {
        public int Id { get; }

        [NotNull]
        public string Name { get;}

        public decimal Price { get;}

        public ServiceBlModel(
            int id,
            [NotNull] string name,
            decimal price
        )
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
