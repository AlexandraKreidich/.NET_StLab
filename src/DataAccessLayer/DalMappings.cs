﻿using AutoMapper;
using DataAccessLayer.Models.DataTransferObjects;
using DataAccessLayer.Models.Entities;
using JetBrains.Annotations;

namespace DataAccessLayer
{
    public static class DalMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserResponse>();
            configuration.CreateMap<Cinema, CinemaModel>();
            configuration.CreateMap<CinemaModel, Cinema>();
            configuration.CreateMap<Hall, HallModel>();
            configuration.CreateMap<Place, PlaceModel>();
            configuration.CreateMap<HallScheme, HallSchemeModel>();
            configuration.CreateMap<Service, ServiceModel>();
            configuration.CreateMap<ServiceModel, Service>();
            configuration.CreateMap<Film, FilmModel>();
            configuration.CreateMap<SessionResponseForFilmsCtrl, SessionModelResponseForFilmsCtrl>();
            configuration.CreateMap<SessionResponseForFilmsCtrl, SessionModelResponseForFilmsCtrl>();
        }
    }
}