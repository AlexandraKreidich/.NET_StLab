using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class ServiceDalDtoModel
    {
        public int Id { get;}

        [NotNull]
        public string Name { get;}

        public decimal Price { get;}

        public ServiceDalDtoModel(
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
