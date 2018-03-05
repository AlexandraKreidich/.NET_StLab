using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IServiceService
    {
        [ItemNotNull]
        Task<IEnumerable<ServiceModel>> GetServices();

        [ItemNotNull]
        Task<ServiceModel> AddOrUpdateService([NotNull] ServiceModel service);

        Task<StoredProcedureExecutionResult> DeleteService(int id);
    }
}
