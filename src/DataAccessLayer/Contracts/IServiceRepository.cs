using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface IServiceRepository
    {
        [ItemNotNull]
        Task<IEnumerable<ServiceResponse>> GetServices();


        Task<int> AddService(ServiceRequest service);

        [ItemNotNull]
        Task<ServiceResponse> UpdateService(ServiceRequest service);
    }
}
