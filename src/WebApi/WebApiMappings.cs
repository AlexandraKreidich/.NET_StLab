using AutoMapper;
using BusinessLayer.Models;
using JetBrains.Annotations;
using WebApi.Models.Place;
using PlaceModelResponse = BusinessLayer.Models.PlaceModelResponse;
using BlServiceModel = BusinessLayer.Models.ServiceModel;
using ApiServiceModel = WebApi.Models.Service.ServiceModel;
using ApiCinemaModel = WebApi.Models.Cinema.CinemaModel;
using ApiFilmModel = WebApi.Models.Film.FilmModel;
using BlFilmModel = BusinessLayer.Models.FilmModel;

namespace WebApi
{
    public static class WebApiMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ApiCinemaModel, CinemaModel>();
            configuration.CreateMap<CinemaModel, ApiCinemaModel>();
            configuration.CreateMap<PlaceModelResponse, PlaceModelResponseForHall>();
            configuration.CreateMap<HallSchemeModelResponse, Models.Hall.HallSchemeModelResponse>();
            configuration.CreateMap<HallModelResponse, Models.Hall.HallModelResponse>();
            configuration.CreateMap<BlServiceModel, ApiServiceModel>();
            configuration.CreateMap<ApiServiceModel, BlServiceModel>();
            configuration.CreateMap<BlFilmModel, ApiFilmModel>();
        }
    }
}
