using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Service;

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
            IEnumerable<ServiceBlModel> services = await _serviceService.GetServices();

            return Ok(
                services.Select(Mapper.Map<ServiceApiModel>)
            );
        }

        // PUT /services -> add or update service
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ServiceApiModel service)
        {
            ServiceBlModel newService = await _serviceService.AddOrUpdateService(Mapper.Map<ServiceBlModel>(service));

            return Ok(
                Mapper.Map<ServiceApiModel>(newService)
            );
        }

        // DELETE /services/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            StoredProcedureExecutionResult result =  await _serviceService.DeleteService(id);

            if (result == StoredProcedureExecutionResult.ForeignKeyViolation)
            {
                return BadRequest(HttpStatusCode.Conflict);
            }

            return Accepted();
        }
    }
}