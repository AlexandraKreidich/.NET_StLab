using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Ticket;

namespace WebApi.Controllers
{
    //User.FindFirst(ClaimTypes.NameIdentifier);
    [Route("api/[controller]")]
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

        // GET /tickets/{id} -> чей это id? пользователя или билета, может вообще нужно и то и то?
        [HttpGet("{id:int}")]
        public IEnumerable<TicketModelResponse> GetById(int id)
        {
            List<TicketModelResponse> tickets = new List<TicketModelResponse>();
            return tickets;
        }

        // PUT /tickets
        [HttpPut]
        public IActionResult Put([FromBody]TicketModelRequest ticket)
        {
            return StatusCode((int)HttpStatusCode.Created);
        }

        // POST /tickets/{id}/pay -> pay for ticket
        [HttpPost]
        [Route("{id:int}/pay")]
        public IActionResult Pay(int id)
        {
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        // DELETE /tickets/{id}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return StatusCode((int)HttpStatusCode.Accepted);
        }
    }
}