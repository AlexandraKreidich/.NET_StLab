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
    }
}
