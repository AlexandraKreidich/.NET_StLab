using AutoMapper;
using BusinessLayer.Models;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;
using DalCinemaModel = DataAccessLayer.Models.DataTransferObjects.CinemaModel;
using BlCinemaModel = DataAccessLayer.Models.DataTransferObjects.CinemaModel;
using BlServiceModel = BusinessLayer.Models.ServiceModel;
using DalServiceModel = DataAccessLayer.Models.DataTransferObjects.ServiceModel;
using DalFilmModel = DataAccessLayer.Models.DataTransferObjects.FilmModel;
using BlFilmModel = BusinessLayer.Models.FilmModel;
using DalStoredProcedureResult = DataAccessLayer.StoredProcedureExecutionResult;
using BlStoredProcedureResult = BusinessLayer.StoredProcedureExecutionResult;
using DalSessionModelResponseForFilmsCtrl = DataAccessLayer.Models.DataTransferObjects.SessionModelResponseForFilmsCtrl;
using BlSessionModelResponseForFilmsCtrl = BusinessLayer.Models.SessionModelResponseForFilmsCtrl;
using BlFilmFilterModel = BusinessLayer.Models.FilmFilterModel;
using DalFilmFilterModel = DataAccessLayer.Models.DataTransferObjects.FilmFilterModel;

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
            configuration.CreateMap<BlServiceModel, DalServiceModel>();
            configuration.CreateMap<DalFilmModel, BlFilmModel>();
            configuration.CreateMap<DalStoredProcedureResult, BlStoredProcedureResult>();
            configuration.CreateMap<DalSessionModelResponseForFilmsCtrl, BlSessionModelResponseForFilmsCtrl>();
            configuration.CreateMap<BlFilmFilterModel, DalFilmFilterModel>();
        }
    }
}
