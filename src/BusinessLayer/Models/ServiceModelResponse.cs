using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class ServiceModelResponse
    {
        public int Id { get; set; }

        [NotNull] public string Name { get; set; }

        public decimal Price { get; set; }

        public ServiceModelResponse(
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
