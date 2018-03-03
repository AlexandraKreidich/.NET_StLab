using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Service;
using ApiServiceModelResponse = WebApi.Models.Service.ServiceModelResponse;
using BlServiceModelResponse = BusinessLayer.Models.ServiceModelResponse;
using ApiServiceModelRequest = WebApi.Models.Service.ServiceModelRequest;
using BlServiceModelRRequest = BusinessLayer.Models.ServiceModelRequest;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        [NotNull]
        private readonly IServiceService _serviceService;

        public ServicesController([NotNull] IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET /services
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<BlServiceModelResponse> services = await _serviceService.GetServices();

            return Ok(
                services.Select(Mapper.Map<ApiServiceModelResponse>)
            );
        }

        // PUT /services -> add service
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ApiServiceModelRequest service)
        {
            BlServiceModelResponse newService = await _serviceService.AddService(Mapper.Map<BlServiceModelRRequest>(service));

            return Ok(
                Mapper.Map<ApiServiceModelResponse>(newService)
            );
        }

        // PUT /services/{id} -> update service
        //[HttpPut("{id:int}")]
        //public IActionResult Put([FromBody]ApiServiceModelRequest service, int id)
        //{
        //    ServiceModelRequestForUpdate serviceModelRequestForUpdate =
        //        new ServiceModelRequestForUpdate(
        //            service.Name,
        //            service.Price,
        //            id
        //        );

        //    BlServiceModelResponse updatedService = _serviceService.UpdateService(serviceModelRequestForUpdate);
        //}

        // DELETE /services/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}