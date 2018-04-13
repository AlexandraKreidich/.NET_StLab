using System;
using AutoMapper;
using BusinessLayer.Models;
using JetBrains.Annotations;
using WebApi.Models.Film;
using WebApi.Models.Hall;
using WebApi.Models.Place;
using WebApi.Models.Service;
using WebApi.Models.Ticket;
using WebApi.Services;
using BlFilmModel = BusinessLayer.Models.FilmModel;
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
            configuration.CreateMap<ServiceBlModelResponseForTicket, ServiceApiModelResponseForTicket>();
            configuration.CreateMap<ServiceApiModelRequestForTicket, ServiceBlModelRequestForTicket>();
            configuration.CreateMap<ServiceApiModel, ServiceBlModel>();
            configuration.CreateMap<FilmModel, BlFilmModel>()
                .ConstructUsing
                (
                    x=> new BlFilmModel(x.Id, x.Name, x.Description,x.StartRentDate,x.EndRentDate)
                );
            configuration.CreateMap<BlFilmModel, FilmModel>()
                .ConstructUsing
                (
                    x => new FilmModel(x.Id, x.Name, x.Description, x.StartRentDate, x.EndRentDate)
                );
            configuration.CreateMap<SessionModelResponse, BlSessionModelResponse>();
            configuration.CreateMap<FilmFilterModel, FilmFilterBlModel>();
            configuration.CreateMap<string, DateTimeOffset>().ConvertUsing<StringToDateTimeConverter>();
            configuration.CreateMap<SessionModelRequest, BlSessionModelRequest>();

            configuration.CreateMap<PlaceTypeBlModel, PlaceTypeApiModel>()
                .ConstructUsing
                (
                    x=> new PlaceTypeApiModel(x.Id, x.Name)
                );
            configuration.CreateMap<TicketBlModelResponse, TicketApiModelResponse>()
                .ConstructUsing
                (
                    x=> new TicketApiModelResponse
                        (
                        x.TicketId,
                        x.FilmName,
                        x.PlaceNumber,
                        x.RowNumber,
                        Mapper.Map<PlaceTypeBlModel, PlaceTypeApiModel>(x.PlaceType),
                        x.HallName,
                        x.CinemaName,
                        x.SessionPrice,
                        Mapper.Map<ServiceBlModelResponseForTicket[], ServiceApiModelResponseForTicket[]>(x.Services),
                        x.TicketStatus,
                        x.CreatedAt
                        )
                );
            configuration.CreateMap<FiltersInfoBlModel, FiltersInfoModel>();
        }
    }
}
