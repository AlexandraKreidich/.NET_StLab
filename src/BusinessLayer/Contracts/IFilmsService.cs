using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;
using BlFilmModel = BusinessLayer.Models.FilmModel;

namespace BusinessLayer.Contracts
{
    public interface IFilmsService
    {
        [ItemNotNull]
        Task<IEnumerable<BlFilmModel>> GetNowPlayingFilms();

        [ItemNotNull]
        Task<IEnumerable<BlFilmModel>> GetFilms();

        [ItemCanBeNull]
        Task<BlFilmModel> GetFilmsById(int id);

        [ItemCanBeNull]
        Task<IEnumerable<SessionModelResponse>> GetSessionsForFilm(int filmId);

        [ItemNotNull]
        Task<FiltersInfoBlModel> GetFiltersInfo();

        [ItemNotNull]
        Task<IEnumerable<BlFilmModel>> SearchFilms([NotNull] FilmFilterBlModel filtersBl);

        [ItemNotNull]
        Task<BlFilmModel> AddOrUpdateFilm([NotNull] BlFilmModel film);
    }
}
