using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;
using DalFilmModel = DataAccessLayer.Models.DataTransferObjects.FilmModel;
using DalFilmFilterModel = DataAccessLayer.Models.DataTransferObjects.FilmFilterModel;
using FilmModel = BusinessLayer.Models.FilmModel;
using SessionModelResponse = BusinessLayer.Models.SessionModelResponse;

namespace BusinessLayer.Services
{
    [UsedImplicitly]
    public class FilmsService : IFilmsService
    {
        [NotNull]
        private readonly IFilmRepository _filmRepository;

        public FilmsService([NotNull] IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public async Task<IEnumerable<FilmModel>> GetNowPlayingFilms()
        {
            IEnumerable<DalFilmModel> films = await _filmRepository.GetNowPlayingFilms();

            return Mapper.Map<IEnumerable<FilmModel>>(films);
        }

        public async Task<IEnumerable<FilmModel>> GetFilms()
        {
            IEnumerable<DalFilmModel> films = await _filmRepository.GetFilms();

            return Mapper.Map<IEnumerable<FilmModel>>(films);
        }

        public async Task<FilmModel> GetFilmsById(int id)
        {
            DalFilmModel film = await _filmRepository.GetFilmById(id);

            return Mapper.Map<FilmModel>(film);
        }

        public async Task<IEnumerable<SessionModelResponse>> GetSessionsForFilm(int filmId)
        {
            DalFilmModel film = await _filmRepository.GetFilmById(filmId);

            if (film == null)
            {
                return null;
            }

            IEnumerable<DataAccessLayer.Models.DataTransferObjects.SessionModelResponse> sessions =
                await _filmRepository.GetSessionsForFilm(filmId);

            return sessions.Select(Mapper.Map<SessionModelResponse>);
        }

        public async Task<FiltersInfoBlModel> GetFiltersInfo()
        {
            IEnumerable<CinemaNamesDalDtoModel> cinemaNames = await _filmRepository.GetCinemaNames();
            IEnumerable<CityNamesDalDtoModel> cityNames = await _filmRepository.GetCityNames();
            IEnumerable<FilmNamesDalDtoModel> filmNames = await _filmRepository.GetFilmNames();

            List<string> cinemaNamesList = new List<string>();

            foreach (var elem in cinemaNames)
            {
                cinemaNamesList.Add(elem.Name);
            }

            List<string> cityNamesList = new List<string>();

            foreach (var elem in cityNames)
            {
                cityNamesList.Add(elem.Name);
            }

            List<string> filmNamesList = new List<string>();

            foreach (var elem in filmNames)
            {
                filmNamesList.Add(elem.Name);
            }
 

            FiltersInfoBlModel filtersInfo = new FiltersInfoBlModel
            (
                filmNamesList.ToArray(),
                cinemaNamesList.ToArray(),
                cityNamesList.ToArray()
            );

            return filtersInfo;
        }

        public async Task<IEnumerable<FilmModel>> SearchFilms(FilmFilterBlModel filtersBl)
        {
            IEnumerable<DalFilmModel> films =
                await _filmRepository.SearchFilms(Mapper.Map<DalFilmFilterModel>(filtersBl));

            return films.Select(Mapper.Map<FilmModel>);
        }

        public async Task<FilmModel> AddOrUpdateFilm(FilmModel film)
        {
            int id = await _filmRepository.AddOrUpdateFilm(Mapper.Map<DalFilmModel>(film));

            return new FilmModel(
                (id != 0) ? id : film.Id,
                film.Name,
                film.Description,
                film.StartRentDate,
                film.EndRentDate
            );
        }
    }
}