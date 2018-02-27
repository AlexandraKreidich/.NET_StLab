using BusinessLayer.Contracts;
using BusinessLayer.Services;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Contracts;
using WebAPI.Services;

namespace WebAPI
{
    public static class WebAPIModule
    {
        public static void Register([NotNull] IServiceCollection collection)
        {
            collection.AddSingleton<IJWTService, JWTService>();
        }
    }
}
