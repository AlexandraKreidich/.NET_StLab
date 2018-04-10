using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface ITicketsService
    {
        [ItemNotNull]
        Task<IEnumerable<TicketBlModelResponse>> GetTicketsForUser(int id);

        [ItemCanBeNull]
        Task<TicketBlModelResponse> GetTicketById(int id);

        [ItemNotNull]
        Task<TicketBlModelResponse> PayForTicket(int ticketId);

        [ItemCanBeNull]
        Task<TicketBlModelResponse> CreateTicket([NotNull] TicketBlModelRequest ticket);

        Task<int> DeleteTicket(int id);

        void ClearBookedTickets();
    }
}
