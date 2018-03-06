using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;
using DalCinemaModel = DataAccessLayer.Models.DataTransferObjects.CinemaModel;
using BlCinemaModel = BusinessLayer.Models.CinemaModel;

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

        public async Task<IEnumerable<BlCinemaModel>> GetCinemas()
        {
            IEnumerable<DalCinemaModel> cinemas = await _cinemaRepository.GetCinemas();

            return cinemas.Select(Mapper.Map<BlCinemaModel>);
        }

        public async Task<BlCinemaModel> GetCinemaById(int id)
        {
            DalCinemaModel cinema = await _cinemaRepository.GetCinemaById(id);

            return (cinema == null) ? null : Mapper.Map<BlCinemaModel>(cinema);
        }

        public async Task<BlCinemaModel> AddOrUpdateCinema(BlCinemaModel cinema)
        {
            DalCinemaModel cinemaRequest = Mapper.Map<DalCinemaModel>(cinema);

            int cinemaResponseId = await _cinemaRepository.AddOrUpdateCinema(cinemaRequest);

            return new BlCinemaModel
            (
                (cinemaResponseId != 0) ? cinemaResponseId : cinema.Id,
                cinema.Name,
                cinema.City,
                cinema.HallsNumber
            );
        }

        public async Task<IEnumerable<HallModelResponse>> GetHalls(int cinemaId)
        {
            DalCinemaModel cinema = await _cinemaRepository.GetCinemaById(cinemaId);

            if (cinema == null)
            {
                return null;
            }

            IEnumerable<HallResponse> halls = await _cinemaRepository.GetHalls(cinemaId);
            List<HallModelResponse> results = new List<HallModelResponse>();

            if (halls != null)
            {
                foreach (HallResponse hall in halls)
                {
                    Task<IEnumerable<PlaceResponse>> t1 = _cinemaRepository.GetPlaces(hall.Id);
                    Task<IEnumerable<HallSchemeResponse>> t2 = _cinemaRepository.GetHallScheme(hall.Id);

                    IEnumerable<PlaceResponse> places = await t1;
                    PlaceModelResponse[] placesResponse = places.Select(Mapper.Map<PlaceModelResponse>).ToArray();

                    IEnumerable<HallSchemeResponse> hallSchemeResponse = await t2;

                    HallSchemeModelResponse[] hallSchemeModelsResponse =
                        hallSchemeResponse.Select(Mapper.Map<HallSchemeModelResponse>).ToArray();

                    results.Add(new HallModelResponse(
                        hall.Id,
                        hall.CinemaId,
                        hall.Name,
                        placesResponse,
                        hallSchemeModelsResponse
                    ));
                }
            }

            return results;
        }
    }
}
