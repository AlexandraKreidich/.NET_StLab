using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using CinemaDalModel = DataAccessLayer.Models.DataTransferObjects.CinemaModel;
using HallDalModel = DataAccessLayer.Models.DataTransferObjects.HallModel;
using PlaceDalModel = DataAccessLayer.Models.DataTransferObjects.PlaceModel;
using HallSchemeDalModel = DataAccessLayer.Models.DataTransferObjects.HallSchemeModel;

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
            IEnumerable<CinemaDalModel> cinemas = await _cinemaRepository.GetCinemas();

            return cinemas.Select(Mapper.Map<CinemaModel>);
        }

        public async Task<CinemaModel> GetCinemaById(int id)
        {
            CinemaDalModel cinema = await _cinemaRepository.GetCinemaById(id);

            return (cinema == null) ? null : Mapper.Map<CinemaModel>(cinema);
        }

        public async Task<CinemaModel> AddOrUpdateCinema(CinemaModel cinema)
        {
            CinemaDalModel cinemaRequest = Mapper.Map<CinemaDalModel>(cinema);

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
            CinemaDalModel cinema = await _cinemaRepository.GetCinemaById(cinemaId);

            if (cinema == null)
            {
                return null;
            }

            IEnumerable<HallDalModel> halls = await _cinemaRepository.GetHalls(cinemaId);
            List<HallModelForApi> results = new List<HallModelForApi>();

            if (halls != null)
            {
                foreach (HallDalModel hall in halls)
                {
                    Task<IEnumerable<PlaceDalModel>> t1 = _cinemaRepository.GetPlaces(hall.Id);
                    Task<IEnumerable<HallSchemeDalModel>> t2 = _cinemaRepository.GetHallScheme(hall.Id);

                    IEnumerable<PlaceDalModel> places = await t1;
                    PlaceModel[] placesArray = places.Select(Mapper.Map<PlaceModel>).ToArray();

                    IEnumerable<HallSchemeDalModel> hallSchemeResponse = await t2;

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
