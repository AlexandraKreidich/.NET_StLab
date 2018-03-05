using AutoMapper;
using BusinessLayer.Models;
using JetBrains.Annotations;
using WebApi.Models.Place;
using PlaceModelResponse = BusinessLayer.Models.PlaceModelResponse;
using ApiServiceModelResponse = WebApi.Models.Service.ServiceModelResponse;
using BlServiceModelResponse = BusinessLayer.Models.ServiceModelResponse;
using ApiServiceModelRequest = WebApi.Models.Service.ServiceModelRequest;
using BlServiceModelRRequest = BusinessLayer.Models.ServiceModelRequest;
using BlServiceModelRequestForUpdate = BusinessLayer.Models.ServiceModelRequestForUpdate;
using ApiServiceModelRequestForUpdate = WebApi.Models.Service.ServiceModelRequestForUpdate;
using ApiCinemaModel = WebApi.Models.Cinema.CinemaModel;

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
            configuration.CreateMap<ApiServiceModelResponse, BlServiceModelResponse>();
            configuration.CreateMap<ApiServiceModelRequest, BlServiceModelRRequest>();
            configuration.CreateMap<ApiServiceModelRequestForUpdate, BlServiceModelRequestForUpdate>();
        }
    }
}
