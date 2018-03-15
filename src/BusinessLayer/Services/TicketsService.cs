using BusinessLayer.Contracts;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;

namespace BusinessLayer.Services
{
    internal class TicketsService : ITicketsService
    {
        [NotNull] private readonly ITicketsRepository _ticketsRepository;

        public TicketsService([NotNull] ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }
    }
}
