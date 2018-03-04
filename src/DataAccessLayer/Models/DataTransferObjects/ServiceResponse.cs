using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class ServiceResponse
    {
        public int Id { get; set; }

        [NotNull] public string Name { get; set; }

        public decimal Price { get; set; }

        public ServiceResponse(
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
