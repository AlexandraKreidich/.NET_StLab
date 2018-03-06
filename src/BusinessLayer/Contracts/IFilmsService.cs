using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Models;
using DalFilmModel = DataAccessLayer.Models.DataTransferObjects.FilmModel;
using BlFilmModel = BusinessLayer.Models.FilmModel;

namespace BusinessLayer.Contracts
{
    public interface IFilmsService
    {
        Task<IEnumerable<BlFilmModel>> GetNowPlayingFilms();
    }
}
