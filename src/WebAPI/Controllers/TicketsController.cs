using System;
using System.Collections.Generic;
using System.Linq;
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
        // POST /tickets/add
        [HttpPost]
        public IActionResult Post([FromBody]TicketModelRequest ticket)
        {
            return null;
        }

        /*
        // GET /tickets/{id}
        [HttpPost("{id:int}")]
        public IEnumerable<TicketModelResponse> GetTicketsForUserId([FromBody]int id)
        {
            List<TicketModelResponse> tickets = new List<TicketModelResponse>();
            return tickets;
        } -> user */
    }
}