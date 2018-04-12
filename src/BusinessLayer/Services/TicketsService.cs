﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace BusinessLayer.Services
{
    [UsedImplicitly]
    internal class TicketsService : ITicketsService
    {
        [NotNull] private readonly ITicketsRepository _ticketsRepository;

        public TicketsService([NotNull] ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }

        public async Task<IEnumerable<TicketBlModelResponse>> GetTicketsForUser(int id)
        {
            IEnumerable<TicketDalDtoModelResponse> tickets = await _ticketsRepository.GetTicketsForUser(id);

            List<TicketBlModelResponse> ticketsBlResponse = new List<TicketBlModelResponse>();

            foreach (TicketDalDtoModelResponse ticket in tickets)
            {
                IEnumerable<ServiceDalDtoModel> services =
                    await _ticketsRepository.GetServicesForTicket(ticket.TicketId);

                ServiceBlModel[] servicesArray = services.Select(Mapper.Map<ServiceBlModel>).ToArray();

                ticketsBlResponse.Add
                (
                    new TicketBlModelResponse
                    (
                        ticket.TicketId,
                        ticket.FilmName,
                        ticket.PlaceNumber,
                        ticket.RowNumber,
                        new PlaceTypeBlModel
                        (
                            ticket.PlaceTypeId,
                            ticket.PlaceType
                        ),
                        ticket.HallName,
                        ticket.CinemaName,
                        ticket.SessionPrice,
                        servicesArray,
                        ticket.TicketStatus,
                        ticket.CreatedAt
                    )
                );
            }

            return ticketsBlResponse;
        }

        public async Task<TicketBlModelResponse> GetTicketById(int id)
        {
            TicketDalDtoModelResponse ticket = await _ticketsRepository.GetTicketById(id);

            if (ticket != null)
            {
                IEnumerable<ServiceDalDtoModel> services =
                    await _ticketsRepository.GetServicesForTicket(ticket.TicketId);

                ServiceBlModel[] servicesArray = services.Select(Mapper.Map<ServiceBlModel>).ToArray();

                return new TicketBlModelResponse
                (
                    ticket.TicketId,
                    ticket.FilmName,
                    ticket.PlaceNumber,
                    ticket.RowNumber,
                    new PlaceTypeBlModel
                    (
                        ticket.PlaceTypeId,
                        ticket.PlaceType
                    ),
                    ticket.HallName,
                    ticket.CinemaName,
                    ticket.SessionPrice,
                    servicesArray,
                    ticket.TicketStatus,
                    ticket.CreatedAt
                );

            }

            return null;
        }

        public async Task<TicketBlModelResponse> PayForTicket(int ticketId)
        {
            _ticketsRepository.PayForTicket(ticketId);

            return await GetTicketById(ticketId) ?? throw new InvalidOperationException();
        }

        public async Task<TicketBlModelResponse> CreateTicket(TicketBlModelRequest ticket)
        {
            TicketDalDtoModelRequest ticketRequest = new TicketDalDtoModelRequest
                (
                    ticket.UserId,
                    ticket.PriceId
                );

            (DataAccessLayer.StoredProcedureExecutionResult result, int id) resultTuple
                = await _ticketsRepository.CreateTicket(ticketRequest);

            if (resultTuple.result == DataAccessLayer.StoredProcedureExecutionResult.Ok)
            {
                if (ticket.Services != null)
                {
                    foreach (int service in ticket.Services)
                    {
                        _ticketsRepository.AddServiceToTicket(resultTuple.id, service);
                    }
                }
<<<<<<< HEAD
                
                return await GetTicketById(resultTuple.id);
=======

                return await GetTicketById(resultTuple.Item2);
>>>>>>> FluentSheduler added & job for clearing booked tickets
            }
            else
            {
                return null;
            }
        }

        public async Task<int> DeleteTicket(int id)
        {
            if (await GetTicketById(id) != null)
            {
                _ticketsRepository.DeleteTicket(id);

                return id;
            }

            return 0;
        }

        public void ClearBookedTickets()
        {
            _ticketsRepository.ClearBookedTickets();
        }
    }
}
