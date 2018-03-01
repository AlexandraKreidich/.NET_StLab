using AutoMapper;
using JetBrains.Annotations;
using BlCinemaModelResponse = BusinessLayer.Models.CinemaModelResponse;
using ApiCinemaModelResponse = WebApi.Models.Cinema.CinemaModelResponse;

namespace WebApi
{
    public static class WebApiMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<BlCinemaModelResponse, ApiCinemaModelResponse>();
        }
    }
}
