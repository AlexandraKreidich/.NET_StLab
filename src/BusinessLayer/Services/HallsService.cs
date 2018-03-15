using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using DalHallModel = DataAccessLayer.Models.DataTransferObjects.HallModel;
using DalPlaceModel = DataAccessLayer.Models.DataTransferObjects.PlaceModel;
using DalHallSchemeModel = DataAccessLayer.Models.DataTransferObjects.HallSchemeModel;

namespace BusinessLayer.Services
{
    [UsedImplicitly]
    internal class HallsService : IHallsService
    {
        [NotNull]
        private readonly IHallsRepository _hallsRepository;

        [NotNull]
        private readonly ICinemaRepository _cinemaRepository;

        public HallsService([NotNull] IHallsRepository hallsRepository, [NotNull] ICinemaRepository cinemaRepository)
        {
            _hallsRepository = hallsRepository;
            _cinemaRepository = cinemaRepository;
        }

        public async Task<HallModelForApi> GetHall(int id)
        {
            DalHallModel hall = await _hallsRepository.GetHall(id);

            if (hall == null)
            {
                return null;
            }

            Task<IEnumerable<DalPlaceModel>> t1 = _cinemaRepository.GetPlaces(hall.Id);
            Task<IEnumerable<DalHallSchemeModel>> t2 = _cinemaRepository.GetHallScheme(hall.Id);

            IEnumerable<DalPlaceModel> places = await t1;
            PlaceModel[] placesArray = places.Select(Mapper.Map<PlaceModel>).ToArray();

            IEnumerable<DalHallSchemeModel> hallSchemeResponse = await t2;
            HallSchemeModel[] hallSchemeModels =
                hallSchemeResponse.Select(Mapper.Map<HallSchemeModel>).ToArray();

            return new HallModelForApi(
                hall.Id,
                hall.CinemaId,
                hall.Name,
                placesArray,
                hallSchemeModels
            );
        }

        public async Task<HallModelForApi> AddOrOrUpdateHall(HallModelForApi hall)
        {
            HallModel hallRequest = new HallModel()
            {
                Id = hall.Id,
                CinemaId = hall.CinemaId,
                Name = hall.Name
            };

            int hallModelResponseId = await _hallsRepository.AddOrUpdateHall(Mapper.Map<DalHallModel>(hallRequest));

            DalHallModel hallModelResponse = new DalHallModel(
                (hallModelResponseId != 0) ? hallModelResponseId : hall.Id,
                hall.CinemaId,
                hall.Name
            );

            List<DalPlaceModel> placesList = new List<DalPlaceModel>();

            if (hall.Places != null)
            {

                foreach (PlaceModel place in hall.Places)
                {
                    PlaceModel placeRequest = new PlaceModel(
                        place.Id,
                        place.HallId,
                        place.Type,
                        place.RowNumber,
                        place.PlaceNumber
                    );

                    int placeResponseId =
                        await _hallsRepository.AddOrUpdatePlace(Mapper.Map<DalPlaceModel>(placeRequest));

                    DalPlaceModel placeResponse = new DalPlaceModel(
                        (placeResponseId != 0) ? placeResponseId : place.Id,
                        place.HallId,
                        place.Type,
                        place.PlaceNumber,
                        place.RowNumber
                    );

                    placesList.Add(placeResponse);
                }
            }

            List<DalHallSchemeModel> schemeModelList = new List<DalHallSchemeModel>();

            if (hall.HallSchemeModels != null)
            {
                foreach (var hallScheme in hall.HallSchemeModels)
                {
                    HallSchemeModel hallSchemeRequest = new HallSchemeModel(
                        hallScheme.Id,
                        hallScheme.HallId,
                        hallScheme.RowNumber,
                        hallScheme.PlacesCount
                    );

                    int hallSchemeResponseId =
                        await _hallsRepository.AddOrUpdateHallScheme(Mapper.Map<DalHallSchemeModel>(hallSchemeRequest));

                    DalHallSchemeModel hallSchemeResponse = new DalHallSchemeModel(
                        (hallSchemeResponseId != 0) ? hallSchemeResponseId : hallSchemeRequest.Id,
                        hallSchemeRequest.HallId,
                        hallSchemeRequest.RowNumber,
                        hallSchemeRequest.PlacesCount
                    );

                    schemeModelList.Add(hallSchemeResponse);
                }
            }

            HallModelForApi hallModelResponseForApi = new HallModelForApi(
                hallModelResponse.Id,
                hallModelResponse.CinemaId,
                hallModelResponse.Name,
                placesList.Select(Mapper.Map<PlaceModel>).ToArray(),
                schemeModelList.Select(Mapper.Map<HallSchemeModel>).ToArray()
            );

            return hallModelResponseForApi;
        }
    }
}
