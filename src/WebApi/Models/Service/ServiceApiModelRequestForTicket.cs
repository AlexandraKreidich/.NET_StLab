using JetBrains.Annotations;

namespace WebApi.Models.Service
{
    [UsedImplicitly]
    public class ServiceApiModelRequestForTicket
    {
        public int Id { get; }

        public int Amount { get; }

        public ServiceApiModelRequestForTicket(
            int id,
            int amount
        )
        {
            Id = id;
            Amount = amount;
        }
    }
}
