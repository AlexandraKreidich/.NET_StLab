﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        // GET /services
        [HttpGet]
        public IEnumerable<ServiceModelResponse> Get(){
            List<ServiceModelResponse> services = new List<ServiceModelResponse>();
            return services;
        }

        // PUT /services
        [HttpPost]
        public IActionResult Put(ServiceModelRequest service){
            return StatusCode((int)System.Net.HttpStatusCode.Created);
        }

        // DELETE /services/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id){
            return StatusCode((int)System.Net.HttpStatusCode.Accepted);
        }
    }
}