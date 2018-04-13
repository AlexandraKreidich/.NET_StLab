using BusinessLayer.Contracts;
using FluentScheduler;
using JetBrains.Annotations;

namespace WebApi.Services
{
    public class ClearBookedTicketsJob : IJob
    {
        private readonly ITicketsService _ticketsService;

        public ClearBookedTicketsJob(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        public void Execute()
        {
            _ticketsService.ClearBookedTickets();
        }
    }

    [UsedImplicitly]
    public class BackgroundJobsRegistry : Registry
    {
        public BackgroundJobsRegistry(ITicketsService ticketsService)
        {
            Schedule(() => new ClearBookedTicketsJob(ticketsService)).ToRunNow().AndEvery(1).Days().At(00, 00);
        }
    }
}
