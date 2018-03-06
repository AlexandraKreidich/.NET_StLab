using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;

namespace DataAccessLayer.Contracts
{
    public interface IFilmRepository
    {
        Task<IEnumerable<FilmModel>> GetNowPlayingFilms();
    } 
}
