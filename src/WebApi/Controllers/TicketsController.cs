﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using JetBrains.Annotations;
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
        [NotNull]
        private readonly ITicketsService _ticketsService;

        public TicketsController([NotNull] ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        // GET /tickets

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int userId = HttpContext.User.GetUserId();

            IEnumerable<TicketBlModelResponse> tickets = await _ticketsService.GetTicketsForUser(userId);

            return Ok(
                tickets.Select(Mapper.Map<TicketApiModelResponse>)
            );
        }

        // GET /tickets/{id}

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            TicketBlModelResponse ticket = await _ticketsService.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(
                Mapper.Map<TicketApiModelResponse>(ticket)
            );
        }

        // PUT /tickets

        [HttpPut]
        public IActionResult Put([NotNull] [FromBody] TicketApiModelRequest ticket)
        {
            TicketBlModelRequest ticketRequest = new TicketBlModelRequest
            (
                HttpContext.User.GetUserId(),
                ticket.PriceId,
                ticket.Status,
                ticket.Services

            );

            _ticketsService.CreateTicket(ticketRequest);

            return Ok();
        }

        // POST /tickets/{id}/pay

        [HttpPost]
        [Route("{id:int}/pay")]
        public async Task<IActionResult> Pay(int id)
        {
            TicketBlModelResponse ticket = await _ticketsService.PayForTicket(id);

            return Ok(
                Mapper.Map<TicketApiModelResponse>(ticket)
            );
        }

        // DELETE /tickets/{id}

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _ticketsService.DeleteTicket(id) == 0)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}