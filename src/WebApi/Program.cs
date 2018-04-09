using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using FluentScheduler;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var registry = new Registry();
            //registry.Schedule<MyJob>().ToRunNow().AndEvery(2).Seconds();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }

}
