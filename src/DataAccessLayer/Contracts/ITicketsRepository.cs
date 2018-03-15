using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface ITicketsRepository
    {
        [ItemNotNull]
        Task<IEnumerable<TicketDalDtoModelResponse>> GetTicketsForUser(int id);

        [ItemCanBeNull]
        Task<TicketDalDtoModelResponse> GetTicketById(int id);

        void CreateTicket([NotNull] TicketDalDtoModelRequest ticket);

        void AddServiceToTicket(int ticketId, int serviceId);

        Task<TicketDalDtoModelResponse> PayForTicket(int ticketId);

        void DeleteTicket(int id);
    }
}
