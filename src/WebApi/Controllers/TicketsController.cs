using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
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
        // GET /tickets (for user)
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            int userId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);



            throw new NotImplementedException();
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