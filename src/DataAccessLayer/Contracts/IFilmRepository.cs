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

        [ItemCanBeNull]
        Task<IEnumerable<SessionModelResponseForFilmsCtrl>> GetSessionsForFilm(int filmId);

        [ItemCanBeNull]
        Task<IEnumerable<SessionModelResponseForFilmsCtrl>> SearchFilms([NotNull] FilmFilterModel filters);

        [ItemNotNull]
        Task<int> AddOrUpdateFilm([NotNull] FilmModel film);
    } 
}
