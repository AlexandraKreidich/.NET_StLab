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

        [ItemNotNull]
        Task<IEnumerable<ServiceDalDtoModelResponseForTicket>> GetServicesForTicket(int ticketId);

        void PayForTicket(int ticketId);

        Task<CreateTicketResponseDalDtoModel> CreateTicket([NotNull] TicketDalDtoModelRequest ticket);

        void AddServiceToTicket([NotNull] ServiceDalDtoModelRequestForTicket service);

        void DeleteTicket(int id);

        void ClearBookedTickets();
    }
}
