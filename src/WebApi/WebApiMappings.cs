using AutoMapper;
using JetBrains.Annotations;
using WebApi.Models.Cinema;
using WebApi.Models.Place;
using WebApi.Models.Hall;
using WebApi.Models.Service;
using WebApi.Models.Session;
using WebApi.Models.Film;
using HallModelForApi = BusinessLayer.Models.HallModelForApi;
using BlServiceModel = BusinessLayer.Models.ServiceModel;
using BlFilmModel = BusinessLayer.Models.FilmModel;
using BlSessionModelResponseForFilmsCtrl = BusinessLayer.Models.SessionModelResponseForFilmsCtrl;
using BlFilmFilterModel = BusinessLayer.Models.FilmFilterModel;
using PlaceModel = BusinessLayer.Models.PlaceModel;

namespace WebApi
{
    public static class WebApiMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CinemaModel, CinemaModel>();
            configuration.CreateMap<CinemaModel, CinemaModel>();
            configuration.CreateMap<PlaceModel, PlaceModelForHall>();
            configuration.CreateMap<HallSchemeModel, HallSchemeModel>();
            configuration.CreateMap<HallModelForApi, HallModel>();
            configuration.CreateMap<BlServiceModel, ServiceModel>();
            configuration.CreateMap<ServiceModel, BlServiceModel>();
            configuration.CreateMap<BlFilmModel, FilmModel>();
            configuration.CreateMap<SessionModelResponseForFilmsCtrl, BlSessionModelResponseForFilmsCtrl>();
            configuration.CreateMap<FilmFilterModel, BlFilmFilterModel>();
        }
    }
}
