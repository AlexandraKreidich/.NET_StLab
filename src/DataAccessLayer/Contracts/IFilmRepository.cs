using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface IFilmRepository
    {
        [ItemNotNull]
        Task<IEnumerable<FilmModel>> GetNowPlayingFilms();

        [ItemNotNull]
        Task<IEnumerable<FilmModel>> GetFilms();

        [ItemCanBeNull]
        Task<FilmModel> GetFilmById(int id);

        [ItemNotNull]
        Task<IEnumerable<SessionModelResponse>> GetSessionsForFilm(int filmId);

        [ItemNotNull]
        Task<IEnumerable<CinemaNamesDalDtoModel>> GetCinemaNames();

        [ItemNotNull]
        Task<IEnumerable<CityNamesDalDtoModel>> GetCityNames();

        [ItemNotNull]
        Task<IEnumerable<FilmNamesDalDtoModel>> GetFilmNames();

        [ItemNotNull]
        Task<IEnumerable<FilmModel>> SearchFilms([NotNull] FilmFilterModel filters);

        Task<int> AddOrUpdateFilm([NotNull] FilmModel film);
    }
}
