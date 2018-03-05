using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IServiceService
    {
        [ItemNotNull]
        Task<IEnumerable<ServiceModelResponse>> GetServices();

        [ItemNotNull]
        Task<ServiceModelResponse> AddService([NotNull] ServiceModelRequest service);

        [ItemNotNull]
        Task<ServiceModelResponse> UpdateService([NotNull] ServiceModelRequest service);
    }
}
