using JetBrains.Annotations;

namespace WebApi.Models.Service
{
    public class ServiceModelResponse : ServiceModelBase
    {
        public int Id { get; }

        public ServiceModelResponse(
            [NotNull] string name,
            decimal price,
            int id
        ) : base(name, price)
        {
            Id = id;
        }
    }
}
