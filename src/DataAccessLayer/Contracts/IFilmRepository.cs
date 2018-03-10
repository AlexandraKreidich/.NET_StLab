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
        Task<IEnumerable<SessionModelResponse>> GetSessionsForFilm(int filmId);

        [ItemCanBeNull]
        Task<IEnumerable<SessionModelResponse>> SearchFilms([NotNull] FilmFilterModel filters);

        [ItemNotNull]
        Task<int> AddOrUpdateFilm([NotNull] FilmModel film);
    } 
}
