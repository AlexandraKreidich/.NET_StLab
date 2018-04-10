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
        private readonly ILogger _logger;

        [NotNull] 
        private Timer _timer;

        [NotNull] 
        private readonly ITicketsService _ticketsService;

        public TimedHostedService(ILogger<TimedHostedService> logger, ITicketsService ticketsService)
        {
            _logger = logger;
            _ticketsService = ticketsService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(900));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _ticketsService.ClearBookedTickets();
            _logger.LogInformation("Timed Background Service is working.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
