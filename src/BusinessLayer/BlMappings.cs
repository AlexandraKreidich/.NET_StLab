using AutoMapper;
using BusinessLayer.Models;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;
using DalCinemaModel = DataAccessLayer.Models.DataTransferObjects.CinemaModel;
using BlCinemaModel = DataAccessLayer.Models.DataTransferObjects.CinemaModel;

namespace BusinessLayer
{
    public static class BlMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<BlCinemaModel, DalCinemaModel>();
            configuration.CreateMap<HallResponse, HallModel>();
            configuration.CreateMap<HallSchemeResponse, HallModelResponse>();
            configuration.CreateMap<PlaceResponse, PlaceModelResponse>();
            configuration.CreateMap<ServiceResponse, ServiceModelResponse>();
            configuration.CreateMap<ServiceModelRequest, ServiceRequest>();
        }
    }
}
