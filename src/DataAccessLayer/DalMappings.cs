using AutoMapper;
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
            configuration.CreateMap<Hall, HallResponse>();
            configuration.CreateMap<Place, PlaceResponse>();
            configuration.CreateMap<HallScheme, HallSchemeResponse>();
            configuration.CreateMap<Service, ServiceResponse>();
            configuration.CreateMap<ServiceResponse, Service>();
            configuration.CreateMap<ServiceRequest, Service>();
        }
    }
}