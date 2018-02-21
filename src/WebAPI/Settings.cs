using BusinessLayer.Contracts;
using DataAcessLayer.Contracts;
using Microsoft.Extensions.Configuration;

namespace WebAPI
{
    public class Settings : IDalSettings, IBlSettings
    {
        private readonly IConfiguration _configuration;

        public string ConnectionString => _configuration[nameof(ConnectionString)];


        public Settings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}