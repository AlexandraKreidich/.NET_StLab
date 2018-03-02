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
    public class CinemasService : ICinemasService
    {
        [NotNull]
        private readonly ICinemaRepository _cinemaRepository;

        public CinemasService([NotNull] ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<IEnumerable<CinemaModelResponse>> GetCinemas()
        {
            IEnumerable<CinemaResponse> cinemas = await _cinemaRepository.GetCinemas();

            return cinemas.Select(Mapper.Map<CinemaModelResponse>);
        }

        public async Task<CinemaModelResponse> GetCinemaById(int id)
        {
            CinemaResponse cinema = await _cinemaRepository.GetCinemaById(id);

            return (cinema == null) ? null : Mapper.Map<CinemaModelResponse>(cinema);
        }

        public async Task<CinemaModelResponse> AddOrUpdateCinema(CinemaModelRequest cinema)
        {
            CinemaRequest cinemaToAdd = new CinemaRequest(cinema.Name, cinema.City);

            int newCinemaId = await _cinemaRepository.AddOrUpdateCinema(cinemaToAdd);

            return new CinemaModelResponse
            (
                newCinemaId,
                cinema.Name,
                cinema.City,
                0
            );
        }

        public async Task<IEnumerable<HallModelResponse>> GetHalls(int hallId)
        {
            IEnumerable<HallResponse> halls = await _cinemaRepository.GetHalls(hallId);

            List<HallModelResponse> results = new List<HallModelResponse>();

            foreach (HallResponse hall in halls)
            {
                Task<IEnumerable<PlaceResponse>> t1 = _cinemaRepository.GetPlaces(hall.Id);
                Task<IEnumerable<HallSchemeResponse>> t2 = _cinemaRepository.GetHallScheme(hall.Id);

                IEnumerable <PlaceResponse> places = await t1;
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

            return results;
        }
    }
}
