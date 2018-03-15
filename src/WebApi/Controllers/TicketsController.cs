using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Ticket;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "User")]
    public class TicketsController : Controller
    {
        // GET /tickets (for user)
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int userId = HttpContext.User.GetUserId();

            throw new NotImplementedException();
        }

        // GET /tickets/{id}
        [HttpGet("{id:int}")]
        public IEnumerable<TicketApiModelResponse> GetById(int id)
        {
            List<TicketApiModelResponse> tickets = new List<TicketApiModelResponse>();
            return tickets;
        }

        // PUT /tickets
        [HttpPut]
        public IActionResult Put([FromBody]TicketApiModelRequest ticket)
        {
            return StatusCode((int)HttpStatusCode.Created);
        }

        // POST /tickets/{id}/pay
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