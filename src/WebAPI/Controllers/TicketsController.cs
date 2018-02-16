using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Ticket")]
    [Authorize(Roles = "User")]
    public class TicketsController : Controller
    {
        // GET /tickets
        [HttpGet]
        public IEnumerable<TicketModelResponse> Get()
        {
            List<TicketModelResponse> tickets = new List<TicketModelResponse>();
            return tickets;
        }

        // GET /tickets/{id}
        [HttpGet("{id:int}")]
        public IEnumerable<TicketModelResponse> GetById(int id)
        {
            List<TicketModelResponse> tickets = new List<TicketModelResponse>();
            return tickets;
        }

        // PUT /tickets
        [HttpPut]
        public IActionResult Put([FromQuery]int plaseId)
        {
            return StatusCode((int)HttpStatusCode.Created);
        }

        // POST /tickets/{id}/pay
        [HttpPost]
        [Route("{id:int}/pay")]
        public IActionResult Pay(int id)
        {
            return StatusCode((int)HttpStatusCode.NoContent); //Правильный ли код ответа?
        }

        // DELETE /tickets/{id}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return StatusCode((int)HttpStatusCode.Accepted);
        }
    }
}