using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using ServiceModel = DataAccessLayer.Models.DataTransferObjects.ServiceModel;
using DalServiceModel = DataAccessLayer.Models.DataTransferObjects.ServiceModel;

namespace BusinessLayer.Services
{
    [UsedImplicitly]
    public class ServiceService : IServiceService
    {
        [NotNull] 
        private readonly IServiceRepository _serviceRepository;

        public ServiceService([NotNull] IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<ServiceBlModel>> GetServices()
        {
            IEnumerable<ServiceModel> services = await _serviceRepository.GetServices();

            return services.Select(Mapper.Map<ServiceBlModel>);
        }

        public async Task<ServiceBlModel> AddOrUpdateService(ServiceBlModel service)
        {
            int id = await _serviceRepository.AddOrUpdateService(Mapper.Map<DalServiceModel>(service));

            return new ServiceBlModel(
                (id != 0) ? id : service.Id,
                service.Name,
                service.Price
            );
        }

        public async Task<StoredProcedureExecutionResult> DeleteService(int id)
        {
            return Mapper.Map<StoredProcedureExecutionResult>(await _serviceRepository.DeleteService(id));
        }
    }
}
