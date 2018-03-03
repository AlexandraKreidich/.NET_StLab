using AutoMapper;
using BusinessLayer.Models;
using JetBrains.Annotations;
using WebApi.Models.Place;
using BlCinemaModelResponse = BusinessLayer.Models.CinemaModelResponse;
using ApiCinemaModelResponse = WebApi.Models.Cinema.CinemaModelResponse;
using PlaceModelResponse = BusinessLayer.Models.PlaceModelResponse;
using BlCinemaModelRequest = BusinessLayer.Models.CinemaModelRequest;
using ApiCinemaModelRequest = WebApi.Models.Cinema.CinemaModelRequest;
using ApiServiceModelResponse = WebApi.Models.Service.ServiceModelResponse;
using BlServiceModelResponse = BusinessLayer.Models.ServiceModelResponse;
using ApiServiceModelRequest = WebApi.Models.Service.ServiceModelRequest;
using BlServiceModelRRequest = BusinessLayer.Models.ServiceModelRequest;
using BlServiceModelRequestForUpdate = BusinessLayer.Models.ServiceModelRequestForUpdate;
using ApiServiceModelRequestForUpdate = WebApi.Models.Service.ServiceModelRequestForUpdate;

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
            configuration.CreateMap<ApiCinemaModelRequest, BlCinemaModelRequest>();
            configuration.CreateMap<ApiServiceModelResponse, BlServiceModelResponse>();
            configuration.CreateMap<ApiServiceModelRequest, BlServiceModelRRequest>();
            configuration.CreateMap<ApiServiceModelRequestForUpdate, BlServiceModelRequestForUpdate>();
        }
    }
}
