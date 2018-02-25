using BusinessLayer.Contracts;
using DataAcessLayer.Contracts;
using Microsoft.Extensions.Configuration;

namespace WebAPI
{
    public class Settings : IDalSettings, IBlSettings
    {
        private readonly IConfiguration _configuration;

        public string ConnectionString => _configuration[nameof(ConnectionString)];
        public string JWTKey => _configuration[nameof(JWTKey)];
        public string JWTExpireDays => _configuration[nameof(JWTExpireDays)];
        public string JWTIssuer => _configuration[nameof(JWTIssuer)];

        public Settings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}