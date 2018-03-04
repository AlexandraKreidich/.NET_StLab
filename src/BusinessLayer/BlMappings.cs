using AutoMapper;
using BusinessLayer.Models;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace BusinessLayer
{
    public static class BlMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CinemaModelResponse, CinemaResponse>();
            configuration.CreateMap<HallResponse, HallModel>();
            configuration.CreateMap<HallSchemeResponse, HallModelResponse>();
            configuration.CreateMap<PlaceResponse, PlaceModelResponse>();
            configuration.CreateMap<CinemaModelRequestForUpdate, CinemaRequestForUpdate>();
            configuration.CreateMap<ServiceResponse, ServiceModelResponse>();
            configuration.CreateMap<ServiceModelRequest, ServiceRequest>();
        }
    }
}
