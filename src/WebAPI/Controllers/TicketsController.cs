﻿using System;
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

        // GET /tickets/new-ticket -> get ticket that has been created
        [HttpGet]
        [Route("/new-ticket")]
        public TicketModelResponse GetNewTicket(TicketModelRequest ticket)
        {
            TicketModelResponse newTicket = new TicketModelResponse();
            return newTicket;
        }

        // PUT /tickets -> creating the ticket with status in process
        [HttpPut]
        public IActionResult Put(TicketModelRequest ticket)
        {
            return StatusCode((int)HttpStatusCode.Created);
        }

        // POST /tickets/{id}/pay -> pay for ticket
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