using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
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
    }
}
