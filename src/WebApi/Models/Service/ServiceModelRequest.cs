using JetBrains.Annotations;

namespace WebApi.Models.Service
{
    public class ServiceModelRequest : ServiceModelBase
    {
        public ServiceModelRequest(
            [NotNull] string name,
            decimal price
        ):base(name, price){}
    }
}
