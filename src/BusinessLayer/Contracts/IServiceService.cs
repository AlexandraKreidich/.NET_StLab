using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IServiceService
    {
        [ItemNotNull]
        Task<IEnumerable<ServiceBlModel>> GetServices();

        [ItemNotNull]
        Task<ServiceBlModel> AddOrUpdateService([NotNull] ServiceBlModel service);

        Task<StoredProcedureExecutionResult> DeleteService(int id);
    }
}
