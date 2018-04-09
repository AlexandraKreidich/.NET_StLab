using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

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

        public async Task<FullHallBlModel> GetHall(int id)
        {
            HallDalDtoModel hallDalDto = await _hallsRepository.GetHall(id);

            if (hallDalDto == null)
            {
                return null;
            }

            Task<IEnumerable<PlaceDalDtoModel>> t1 = _cinemaRepository.GetPlaces(hallDalDto.Id);
            Task<IEnumerable<HallSchemeDalDtoModel>> t2 = _cinemaRepository.GetHallScheme(hallDalDto.Id);

            IEnumerable<PlaceDalDtoModel> places = await t1;
            PlaceBlModel[] placesBlArray = places.Select
            (
                x => new PlaceBlModel
                    (
                        x.Id,
                        x.HallId,
                        new PlaceTypeBlModel(x.TypeId, x.Type),
                        x.RowNumber,
                        x.PlaceNumber,
                        x.Price,
                        x.PriceId,
                        x.PlaceStatus
                    )
             ).ToArray();

            IEnumerable<HallSchemeDalDtoModel> hallSchemeResponse = await t2;
            HallSchemeBlModel[] hallSchemeBlModels =
                hallSchemeResponse.Select(Mapper.Map<HallSchemeBlModel>).ToArray();

            return new FullHallBlModel(
                hallDalDto.Id,
                hallDalDto.CinemaId,
                hallDalDto.HallName,
                hallDalDto.CinemaName,
                placesBlArray,
                hallSchemeBlModels
            );
        }

        public async Task<FullHallBlModel> GetHallForSession(int hallId, int sessionId)
        {
            HallDalDtoModel hallDalDto = await _hallsRepository.GetHall(hallId);

            if (hallDalDto == null)
            {
                return null;
            }

            Task<IEnumerable<PlaceDalDtoModel>> t1 = _hallsRepository.GetPlacesForSession(hallDalDto.Id, sessionId);
            Task<IEnumerable<HallSchemeDalDtoModel>> t2 = _cinemaRepository.GetHallScheme(hallDalDto.Id);

            IEnumerable<PlaceDalDtoModel> places = await t1;
            PlaceBlModel[] placesBlArray = places.Select
            (
                x => new PlaceBlModel
                (
                    x.Id,
                    x.HallId,
                    new PlaceTypeBlModel(x.TypeId, x.Type),
                    x.RowNumber,
                    x.PlaceNumber,
                    x.Price,
                    x.PriceId,
                    x.PlaceStatus
                )
            ).ToArray();

            IEnumerable<HallSchemeDalDtoModel> hallSchemeResponse = await t2;
            HallSchemeBlModel[] hallSchemeBlModels =
                hallSchemeResponse.Select(Mapper.Map<HallSchemeBlModel>).ToArray();

            return new FullHallBlModel(
                hallDalDto.Id,
                hallDalDto.CinemaId,
                hallDalDto.HallName,
                hallDalDto.CinemaName,
                placesBlArray,
                hallSchemeBlModels
            );
        }

        public async Task<FullHallBlModel> AddOrOrUpdateHall(FullHallBlModel hallBlModel)
        {
            HallBlModel hallBlRequest = new HallBlModel(
                hallBlModel.Id,
                hallBlModel.CinemaId,
                hallBlModel.HallName,
                hallBlModel.CinemaName
            );

            int hallModelResponseId = await _hallsRepository.AddOrUpdateHall(Mapper.Map<HallDalDtoModel>(hallBlRequest));

            HallDalDtoModel hallDalDtoModelResponse = new HallDalDtoModel(
                (hallModelResponseId != 0) ? hallModelResponseId : hallBlModel.Id,
                hallBlModel.CinemaId,
                hallBlModel.HallName,
                hallBlModel.CinemaName
            );

            List<PlaceBlModel> placesList = new List<PlaceBlModel>();

            if (hallBlModel.PlacesBl != null)
            {

                foreach (PlaceBlModel place in hallBlModel.PlacesBl)
                {
                    int placeResponseId =
                        await _hallsRepository.AddOrUpdatePlace
                        (
                            new PlaceDalDtoModel
                            (
                                place.Id,
                                place.HallId,
                                place.Type.Name,
                                place.Type.Id,
                                place.PlaceNumber,
                                place.RowNumber,
                                place.Price,
                                place.PriceId,
                                place.PlaceStatus
                            )
                        );

                    PlaceBlModel placeBlModel = new PlaceBlModel(
                        (placeResponseId != 0) ? placeResponseId : place.Id,
                        place.HallId,
                        new PlaceTypeBlModel
                        (
                            place.Type.Id,
                            place.Type.Name
                        ),
                        place.PlaceNumber,
                        place.RowNumber,
                        place.Price,
                        place.PriceId,
                        place.PlaceStatus
                    );

                    placesList.Add(placeBlModel);
                }
            }

            List<HallSchemeBlModel> schemeModelList = new List<HallSchemeBlModel>();

            if (hallBlModel.HallSchemeBlModels != null)
            {
                foreach (HallSchemeBlModel hallScheme in hallBlModel.HallSchemeBlModels)
                {
                    int hallSchemeResponseId =
                        await _hallsRepository.AddOrUpdateHallScheme(Mapper.Map<HallSchemeDalDtoModel>(hallScheme));

                    HallSchemeBlModel hallSchemeBlModel = new HallSchemeBlModel(
                        (hallSchemeResponseId != 0) ? hallSchemeResponseId : hallScheme.Id,
                        hallScheme.HallId,
                        hallScheme.RowNumber,
                        hallScheme.PlacesCount
                    );

                    schemeModelList.Add(hallSchemeBlModel);
                }
            }

            FullHallBlModel fullHallBlModel = new FullHallBlModel(
                hallDalDtoModelResponse.Id,
                hallDalDtoModelResponse.CinemaId,
                hallDalDtoModelResponse.HallName,
                hallDalDtoModelResponse.CinemaName,
                placesList.ToArray(),
                schemeModelList.ToArray()
            );

            return fullHallBlModel;
        }
    }
}
