using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using DalFilmModel = DataAccessLayer.Models.DataTransferObjects.FilmModel;
using BlFilmModel = BusinessLayer.Models.FilmModel;

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
    }
}
