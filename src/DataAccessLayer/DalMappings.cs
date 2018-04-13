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
            configuration.CreateMap<HallDalModel, HallDalDtoModel>();
            configuration.CreateMap<PlaceDalModel, PlaceDalDtoModel>();
            configuration.CreateMap<HallSchemeDalModel, HallSchemeDalDtoModel>();
            configuration.CreateMap<ServiceDalModel, ServiceDalDtoModel>();
            configuration.CreateMap<ServiceDalModelResponseForTicket, ServiceDalDtoModelResponseForTicket>();
            configuration.CreateMap<ServiceDalDtoModel, ServiceDalModel>();
            configuration.CreateMap<Film, FilmModel>().ConstructUsing
            (
                x=> new FilmModel(x.Id, x.Name, x.Description, x.StartRentDate, x.EndRentDate)
            );
            configuration.CreateMap<FilmModel, Film>();
            configuration.CreateMap<SessionResponse, SessionModelResponse>();
            configuration.CreateMap<SessionResponse, SessionModelResponse>();
            configuration.CreateMap<TicketDalModelResponse, TicketDalDtoModelResponse>();
            configuration.CreateMap<CinemaName, CinemaNamesDalDtoModel>();
            configuration.CreateMap<FilmNames, FilmNamesDalDtoModel>();
            configuration.CreateMap<CityNames, CityNamesDalDtoModel>();
        }
    }
}