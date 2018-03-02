using AutoMapper;
using BusinessLayer.Models;
using JetBrains.Annotations;
using WebApi.Models.Place;
using BlCinemaModelResponse = BusinessLayer.Models.CinemaModelResponse;
using ApiCinemaModelResponse = WebApi.Models.Cinema.CinemaModelResponse;
using PlaceModelResponse = BusinessLayer.Models.PlaceModelResponse;

namespace WebApi
{
    public static class WebApiMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<BlCinemaModelResponse, ApiCinemaModelResponse>();
            configuration.CreateMap<PlaceModelResponse, PlaceModelResponseForHall>();
            configuration.CreateMap<HallSchemeModelResponse, Models.Hall.HallSchemeModelResponse>();
            configuration.CreateMap<HallModelResponse, Models.Hall.HallModelResponse>();
        }
    }
}
