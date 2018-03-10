using AutoMapper;
using BusinessLayer.Models;
using JetBrains.Annotations;
using DalFilmFilterModel = DataAccessLayer.Models.DataTransferObjects.FilmFilterModel;
using DalCinemaModel = DataAccessLayer.Models.DataTransferObjects.CinemaModel;
using DalHallModel = DataAccessLayer.Models.DataTransferObjects.HallModel;
using DalHallSchemeModel = DataAccessLayer.Models.DataTransferObjects.HallSchemeModel;
using DalPlaceModel = DataAccessLayer.Models.DataTransferObjects.PlaceModel;
using DalServiceModel = DataAccessLayer.Models.DataTransferObjects.ServiceModel;
using DalFilmModel = DataAccessLayer.Models.DataTransferObjects.FilmModel;


namespace BusinessLayer
{
    public static class BlMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<DalCinemaModel, CinemaModel>();
            configuration.CreateMap<DalHallModel, HallModel>();
            configuration.CreateMap<DalHallSchemeModel, HallSchemeModel>();
            configuration.CreateMap<DalPlaceModel, PlaceModel>();
            configuration.CreateMap<ServiceModel, DalServiceModel>();
            configuration.CreateMap<DalFilmModel, FilmModel>();
            configuration.CreateMap<DataAccessLayer.Models.DataTransferObjects.SessionModelResponse, SessionModelResponse>();
            configuration.CreateMap<FilmFilterModel, DalFilmFilterModel>();
            configuration.CreateMap<DataAccessLayer.StoredProcedureExecutionResult, StoredProcedureExecutionResult>();
        }
    }
}
