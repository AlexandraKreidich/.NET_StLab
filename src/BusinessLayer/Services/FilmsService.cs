using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using DalFilmModel = DataAccessLayer.Models.DataTransferObjects.FilmModel;
using DalFilmFilterModel = DataAccessLayer.Models.DataTransferObjects.FilmFilterModel;

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

            return films.Select(Mapper.Map<FilmModel>);
        }

        public async Task<IEnumerable<FilmModel>> GetFilms()
        {
            IEnumerable<DalFilmModel> films = await _filmRepository.GetFilms();

            return films.Select(Mapper.Map<FilmModel>);
        }

        public async Task<FilmModel> GetFilmsById(int id)
        {
            DalFilmModel film = await _filmRepository.GetFilmById(id);

            return Mapper.Map<FilmModel>(film);
        }

        public async Task<IEnumerable<SessionModelResponse>> GetSessionsForFilm(int filmId)
        {
            IEnumerable<DataAccessLayer.Models.DataTransferObjects.SessionModelResponse> sessions = await _filmRepository.GetSessionsForFilm(filmId);

            return sessions.Select(Mapper.Map<SessionModelResponse>);
        }

        public async Task<IEnumerable<SessionModelResponse>> SearchFilms(FilmFilterModel filters)
        {
            IEnumerable<DataAccessLayer.Models.DataTransferObjects.SessionModelResponse> sessions = await _filmRepository.SearchFilms(Mapper.Map<DalFilmFilterModel>(filters));

            return sessions.Select(Mapper.Map<SessionModelResponse>);
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

            //return new FilmModel()
            //    {
            //        Description = film.Description,
            //        EndRentDate = film.EndRentDate,
            //        Id = (id != 0) ? id : film.Id,
            //        Name = film.Name,
            //        StartRentDate = film.StartRentDate
            //};
        }
    }
}