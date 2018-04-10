using System;
using System.Threading;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApi.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        [NotNull] 
        private Timer _timer;

        [NotNull] 
        private readonly ITicketsService _ticketsService;

        public TimedHostedService(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(900));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _ticketsService.ClearBookedTickets();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
