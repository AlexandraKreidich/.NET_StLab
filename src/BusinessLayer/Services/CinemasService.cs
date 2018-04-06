using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;
using CinemaDalModel = DataAccessLayer.Models.DataTransferObjects.CinemaModel;
using CinemaModel = BusinessLayer.Models.CinemaModel;

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

        public async Task<IEnumerable<FullHallBlModel>> GetHalls(int cinemaId)
        {
            CinemaDalModel cinema = await _cinemaRepository.GetCinemaById(cinemaId);

            if (cinema == null)
            {
                return null;
            }

            IEnumerable<HallDalDtoModel> halls = await _cinemaRepository.GetHalls(cinemaId);
            List<FullHallBlModel> results = new List<FullHallBlModel>();

            if (halls != null)
            {
                foreach (HallDalDtoModel hall in halls)
                {
                    Task<IEnumerable<PlaceDalDtoModel>> t1 = _cinemaRepository.GetPlaces(hall.Id);
                    Task<IEnumerable<HallSchemeDalDtoModel>> t2 = _cinemaRepository.GetHallScheme(hall.Id);

                    IEnumerable<PlaceDalDtoModel> places = await t1;
                    PlaceBlModel[] placesBlArray = places.Select(
                        x => new PlaceBlModel
                        (
                            x.Id,
                            x.HallId,
                            new PlaceTypeBlModel(x.TypeId, x.Type),
                            x.RowNumber,
                            x.PlaceNumber,
                            x.Price
                        )
                    ).ToArray();

                    IEnumerable<HallSchemeDalDtoModel> hallSchemeResponse = await t2;

                    HallSchemeBlModel[] hallSchemeBlModels =
                        hallSchemeResponse.Select(Mapper.Map<HallSchemeBlModel>).ToArray();

                    results.Add(new FullHallBlModel(
                        hall.Id,
                        hall.CinemaId,
                        hall.Name,
                        placesBlArray,
                        hallSchemeBlModels
                    ));
                }
            }

            return results;
        }
    }
}
