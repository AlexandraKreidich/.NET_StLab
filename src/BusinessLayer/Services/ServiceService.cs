using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace BusinessLayer.Services
{
    public class ServiceService : IServiceService
    {
        [NotNull] private readonly IServiceRepository _serviceRepository;

        public ServiceService([NotNull] IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<ServiceModelResponse>> GetServices()
        {
            IEnumerable<ServiceResponse> services = await _serviceRepository.GetServices();

            return services.Select(Mapper.Map<ServiceModelResponse>);
        }

        public async Task<ServiceModelResponse> AddService(ServiceModelRequest service)
        {
            int id = await _serviceRepository.AddService(Mapper.Map<ServiceRequest>(service));

            return new ServiceModelResponse(
                id,
                service.Name,
                service.Price
            );
        }

        public Task<ServiceModelResponse> UpdateService(ServiceModelRequest service)
        {
            throw new System.NotImplementedException();
        }

    }
}
