using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface ICinemasService
    {
        [ItemNotNull]
        Task<IEnumerable<CinemaModel>> GetCinemas();

        [ItemCanBeNull]
        Task<CinemaModel> GetCinemaById(int id);

        [ItemNotNull]
        Task<CinemaModel> AddOrUpdateCinema([NotNull] CinemaModel cinema);

        [ItemCanBeNull]
        Task<IEnumerable<HallModelForApi>> GetHalls(int cinemaId);
    }
}
