using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using DalFilmModel = DataAccessLayer.Models.DataTransferObjects.FilmModel;
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
    }
}
