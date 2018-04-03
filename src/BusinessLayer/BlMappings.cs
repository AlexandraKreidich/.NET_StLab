using AutoMapper;
using BusinessLayer.Models;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;
using CinemaModel = BusinessLayer.Models.CinemaModel;
using DalFilmFilterModel = DataAccessLayer.Models.DataTransferObjects.FilmFilterModel;
using DalCinemaModel = DataAccessLayer.Models.DataTransferObjects.CinemaModel;
using DalFilmModel = DataAccessLayer.Models.DataTransferObjects.FilmModel;
using FilmModel = BusinessLayer.Models.FilmModel;
using SessionModelResponse = BusinessLayer.Models.SessionModelResponse;


namespace BusinessLayer
{
    public static class BlMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<DalCinemaModel, CinemaModel>();

            configuration.CreateMap<HallDalDtoModel, HallBlModel>();

            configuration.CreateMap<HallSchemeDalDtoModel, HallSchemeBlModel>();

            configuration.CreateMap<ServiceBlModel, ServiceDalDtoModel>();

            configuration.CreateMap<DalFilmModel, FilmModel>().ConstructUsing
            (
                x=> new FilmModel(x.Id, x.Name, x.Description, x.StartRentDate, x.EndRentDate)
            );

            configuration.CreateMap<FilmModel, DalFilmModel>().ConstructUsing
            (
                x => new DalFilmModel(x.Id, x.Name, x.Description, x.StartRentDate, x.EndRentDate)
            );

            configuration.CreateMap<DataAccessLayer.Models.DataTransferObjects.SessionModelResponse, SessionModelResponse>();

            configuration.CreateMap<FilmFilterBlModel, DalFilmFilterModel>();

            configuration.CreateMap<DataAccessLayer.StoredProcedureExecutionResult, StoredProcedureExecutionResult>();
        }
    }
}
