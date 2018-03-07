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
using ApiSessionModelResponseForFilmsCtrl = WebApi.Models.Session.SessionModelResponseForFilmsCtrl;
using BlSessionModelResponseForFilmsCtrl = BusinessLayer.Models.SessionModelResponseForFilmsCtrl;
using BlFilmFilterModel = BusinessLayer.Models.FilmFilterModel;
using ApiFilmFilterModel = WebApi.Models.Film.FilmFilterModel;

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
            configuration.CreateMap<ApiSessionModelResponseForFilmsCtrl, BlSessionModelResponseForFilmsCtrl>();
            configuration.CreateMap<ApiFilmFilterModel, BlFilmFilterModel>();
        }
    }
}
