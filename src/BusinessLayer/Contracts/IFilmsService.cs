using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;
using DalFilmModel = DataAccessLayer.Models.DataTransferObjects.FilmModel;
using BlFilmModel = BusinessLayer.Models.FilmModel;
using DalSessionModelResponseForFilmsCtrl = DataAccessLayer.Models.DataTransferObjects.SessionModelResponseForFilmsCtrl;
using BlSessionModelResponseForFilmsCtrl = BusinessLayer.Models.SessionModelResponseForFilmsCtrl;

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

        [ItemNotNull]
        Task<IEnumerable<BlSessionModelResponseForFilmsCtrl>> GetSessionsForFilm(int filmId);

        [ItemNotNull]
        Task<IEnumerable<SessionModelResponseForFilmsCtrl>> SearchFilms([NotNull] FilmFilterModel filters);
    }
}
