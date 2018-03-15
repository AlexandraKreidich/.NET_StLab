using System;
using AutoMapper;
using BusinessLayer.Models;
using JetBrains.Annotations;
using WebApi.Models.Hall;
using WebApi.Models.Service;
using WebApi.Services;
using BlFilmModel = BusinessLayer.Models.FilmModel;
using BlFilmFilterModel = BusinessLayer.Models.FilmFilterModel;
using BlCinemaModel = BusinessLayer.Models.CinemaModel;
using BlSessionModelResponse = BusinessLayer.Models.SessionModelResponse;
using BlSessionModelRequest = BusinessLayer.Models.SessionModelRequest;
using CinemaModel = WebApi.Models.Cinema.CinemaModel;
using FilmFilterModel = WebApi.Models.Film.FilmFilterModel;
using FilmModel = WebApi.Models.Film.FilmModel;
using SessionModelRequest = WebApi.Models.Session.SessionModelRequest;
using SessionModelResponse = WebApi.Models.Session.SessionModelResponse;

namespace WebApi
{
    public static class WebApiMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CinemaModel, BlCinemaModel>();
            configuration.CreateMap<BlCinemaModel, CinemaModel>();
            configuration.CreateMap<HallSchemeBlModel, HallSchemeApiModel>();
            configuration.CreateMap<FullHallBlModel, HallApiModel>();
            configuration.CreateMap<ServiceBlModel, ServiceApiModel>();
            configuration.CreateMap<ServiceApiModel, ServiceBlModel>();
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
