using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using DalFilmModel = DataAccessLayer.Models.DataTransferObjects.FilmModel;
using BlFilmModel = BusinessLayer.Models.FilmModel;
using DalSessionModelResponseForFilmsCtrl = DataAccessLayer.Models.DataTransferObjects.SessionModelResponseForFilmsCtrl;
using BlSessionModelResponseForFilmsCtrl = BusinessLayer.Models.SessionModelResponseForFilmsCtrl;
using BlFilmFilterModel = BusinessLayer.Models.FilmFilterModel;
using DalFilmFilterModel = DataAccessLayer.Models.DataTransferObjects.FilmFilterModel;

namespace BusinessLayer.Services
{
    public class FilmsService : IFilmsService
    {
        [NotNull]
        private readonly IFilmRepository _filmRepository;

        public FilmsService([NotNull] IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public async Task<IEnumerable<BlFilmModel>> GetNowPlayingFilms()
        {
            IEnumerable<DalFilmModel> films = await _filmRepository.GetNowPlayingFilms();

            return films.Select(Mapper.Map<BlFilmModel>);
        }

        public async Task<IEnumerable<BlFilmModel>> GetFilms()
        {
            IEnumerable<DalFilmModel> films = await _filmRepository.GetFilms();

            return films.Select(Mapper.Map<BlFilmModel>);
        }

        public async Task<BlFilmModel> GetFilmsById(int id)
        {
            DalFilmModel film = await _filmRepository.GetFilmById(id);

            return Mapper.Map<BlFilmModel>(film);
        }

        public async Task<IEnumerable<BlSessionModelResponseForFilmsCtrl>> GetSessionsForFilm(int filmId)
        {
            IEnumerable<DalSessionModelResponseForFilmsCtrl> sessions = await _filmRepository.GetSessionsForFilm(filmId);

            return sessions.Select(Mapper.Map<BlSessionModelResponseForFilmsCtrl>);
        }

        public async Task<IEnumerable<BlSessionModelResponseForFilmsCtrl>> SearchFilms(BlFilmFilterModel filters)
        {
            IEnumerable<DalSessionModelResponseForFilmsCtrl> sessions = await _filmRepository.SearchFilms(Mapper.Map<DalFilmFilterModel>(filters));

            return sessions.Select(Mapper.Map<BlSessionModelResponseForFilmsCtrl>);
        }

        public async Task<BlFilmModel> AddOrUpdateFilm(BlFilmModel film)
        {
            int id = await _filmRepository.AddOrUpdateFilm(Mapper.Map<DalFilmModel>(film));

            return new BlFilmModel(
                (id != 0) ? id : film.Id,
                film.Name,
                film.Description,
                film.EndRentDate,
                film.StartRentDate
            );
        }
    }
}
