using AutoMapper;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Contracts;
using WebApi.Services;
using BlCinemaModelResponse = BusinessLayer.Models.CinemaModelResponse;
using ApiCinemaModelResponse = WebApi.Models.Cinema.CinemaModelResponse;

namespace WebApi
{
    public static class WebApiModule
    {
        public static void Register([NotNull] IServiceCollection collection)
        {
            collection.AddSingleton<IJwtService, JwtService>();

            Mapper.Initialize(cfg => {
                    cfg.CreateMap<BlCinemaModelResponse, ApiCinemaModelResponse>();
            });
        }
    }
}
