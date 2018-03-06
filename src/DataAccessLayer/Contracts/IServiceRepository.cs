using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface IServiceRepository
    {
        [ItemNotNull]
        Task<IEnumerable<ServiceModel>> GetServices();

        Task<int> AddOrUpdateService([NotNull] ServiceModel service);

        Task<StoredProcedureExecutionResult> DeleteService(int id);
    }
}
