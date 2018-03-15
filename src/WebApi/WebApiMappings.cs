using System;
using AutoMapper;
using JetBrains.Annotations;
using WebApi.Models.Cinema;
using WebApi.Models.Place;
using WebApi.Models.Hall;
using WebApi.Models.Service;
using WebApi.Models.Session;
using WebApi.Models.Film;
using WebApi.Services;
using HallModelForApi = BusinessLayer.Models.HallModelForApi;
using BlServiceModel = BusinessLayer.Models.ServiceModel;
using BlFilmModel = BusinessLayer.Models.FilmModel;
using BlFilmFilterModel = BusinessLayer.Models.FilmFilterModel;
using PlaceModel = BusinessLayer.Models.PlaceModel;
using BlHallSchemeModel = BusinessLayer.Models.HallSchemeModel;
using BlCinemaModel = BusinessLayer.Models.CinemaModel;
using BlSessionModelResponse = BusinessLayer.Models.SessionModelResponse;
using BlSessionModelRequest = BusinessLayer.Models.SessionModelRequest;

namespace WebApi
{
    public static class WebApiMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CinemaModel, BlCinemaModel>();
            configuration.CreateMap<BlCinemaModel, CinemaModel>();
            configuration.CreateMap<PlaceModel, PlaceModelForHall>();
            configuration.CreateMap<BlHallSchemeModel, HallSchemeModel>();
            configuration.CreateMap<HallModelForApi, HallModel>();
            configuration.CreateMap<BlServiceModel, ServiceModel>();
            configuration.CreateMap<ServiceModel, BlServiceModel>();
            configuration.CreateMap<FilmModel, BlFilmModel>().ConstructUsing
            (
                x=> new BlFilmModel(x.Id, x.Name, x.Description,x.StartRentDate,x.EndRentDate)
            );
            configuration.CreateMap<BlFilmModel, FilmModel>().ConstructUsing
            (
                x => new FilmModel(x.Id, x.Name, x.Description, x.StartRentDate, x.EndRentDate)
            );
            configuration.CreateMap<SessionModelResponse, BlSessionModelResponse>();
            configuration.CreateMap<FilmFilterModel, BlFilmFilterModel>();
            configuration.CreateMap<string, DateTimeOffset>().ConvertUsing<StringToDateTimeConverter>();
            configuration.CreateMap<SessionModelRequest, BlSessionModelRequest>();
        }
    }
}
