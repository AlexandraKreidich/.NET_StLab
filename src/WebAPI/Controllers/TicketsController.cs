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

        // GET /tickets/{id}
        [HttpGet("{id:int}")]
        public IEnumerable<TicketModelResponse> GetById(int id)
        {
            List<TicketModelResponse> tickets = new List<TicketModelResponse>();
            return tickets;
        }

        // GET /tickets/new-ticket/{place-id} -> get ticket that has been created
        [HttpGet]
        [Route("/new-ticket/{id:int}")]
        public TicketModelResponse GetNewTicket(int placeId)
        {
            TicketModelResponse newTicket = new TicketModelResponse();
            return newTicket;
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