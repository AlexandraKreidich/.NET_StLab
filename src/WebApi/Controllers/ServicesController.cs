using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer;
using BusinessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using ApiServiceModel = WebApi.Models.Service.ServiceModel;
using BlServiceModel = BusinessLayer.Models.ServiceModel;

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
            IEnumerable<BlServiceModel> services = await _serviceService.GetServices();

            return Ok(
                services.Select(Mapper.Map<ApiServiceModel>)
            );
        }

        // PUT /services -> add or update service
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ApiServiceModel service)
        {
            BlServiceModel newService = await _serviceService.AddOrUpdateService(Mapper.Map<BlServiceModel>(service));

            return Ok(
                Mapper.Map<ApiServiceModel>(newService)
            );
        }

        // DELETE /services/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
             StoredProcedureExecutionResult result =  await _serviceService.DeleteService(id);

            if (result == StoredProcedureExecutionResult.Ok)
            {
                return Ok();
            }

            return BadRequest(HttpStatusCode.NotAcceptable);
        }
    }
}