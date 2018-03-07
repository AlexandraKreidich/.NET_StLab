using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using DalCinemaModel = DataAccessLayer.Models.DataTransferObjects.CinemaModel;
using DalHallModel = DataAccessLayer.Models.DataTransferObjects.HallModel;
using DalPlaceModel = DataAccessLayer.Models.DataTransferObjects.PlaceModel;
using DalHallSchemeModel = DataAccessLayer.Models.DataTransferObjects.HallSchemeModel;

namespace BusinessLayer.Services
{
    [UsedImplicitly]
    public class CinemasService : ICinemasService
    {
        [NotNull]
        private readonly ICinemaRepository _cinemaRepository;

        public CinemasService([NotNull] ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<IEnumerable<CinemaModel>> GetCinemas()
        {
            IEnumerable<DalCinemaModel> cinemas = await _cinemaRepository.GetCinemas();

            return cinemas.Select(Mapper.Map<CinemaModel>);
        }

        public async Task<CinemaModel> GetCinemaById(int id)
        {
            DalCinemaModel cinema = await _cinemaRepository.GetCinemaById(id);

            return (cinema == null) ? null : Mapper.Map<CinemaModel>(cinema);
        }

        public async Task<CinemaModel> AddOrUpdateCinema(CinemaModel cinema)
        {
            DalCinemaModel cinemaRequest = Mapper.Map<DalCinemaModel>(cinema);

            int cinemaResponseId = await _cinemaRepository.AddOrUpdateCinema(cinemaRequest);

            return new CinemaModel
            (
                (cinemaResponseId != 0) ? cinemaResponseId : cinema.Id,
                cinema.Name,
                cinema.City,
                cinema.HallsNumber
            );
        }

        public async Task<IEnumerable<HallModelForApi>> GetHalls(int cinemaId)
        {
            DalCinemaModel cinema = await _cinemaRepository.GetCinemaById(cinemaId);

            if (cinema == null)
            {
                return null;
            }

            IEnumerable<DalHallModel> halls = await _cinemaRepository.GetHalls(cinemaId);
            List<HallModelForApi> results = new List<HallModelForApi>();

            if (halls != null)
            {
                foreach (DalHallModel hall in halls)
                {
                    Task<IEnumerable<DalPlaceModel>> t1 = _cinemaRepository.GetPlaces(hall.Id);
                    Task<IEnumerable<DalHallSchemeModel>> t2 = _cinemaRepository.GetHallScheme(hall.Id);

                    IEnumerable<DalPlaceModel> places = await t1;
                    PlaceModel[] placesArray = places.Select(Mapper.Map<PlaceModel>).ToArray();

                    IEnumerable<DalHallSchemeModel> hallSchemeResponse = await t2;

                    HallSchemeModel[] hallSchemeModels =
                        hallSchemeResponse.Select(Mapper.Map<HallSchemeModel>).ToArray();

                    results.Add(new HallModelForApi(
                        hall.Id,
                        hall.CinemaId,
                        hall.Name,
                        placesArray,
                        hallSchemeModels
                    ));
                }
            }

            return results;
        }
    }
}
