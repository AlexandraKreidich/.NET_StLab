using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface ICinemaRepository
    {
        [ItemNotNull]
        Task<IEnumerable<CinemaModel>> GetCinemas();

        [ItemCanBeNull]
        Task<CinemaModel> GetCinemaById(int id);

        Task<int> AddOrUpdateCinema([NotNull] CinemaModel cinema);

        [ItemCanBeNull]
        Task<IEnumerable<HallModel>> GetHalls(int cinemaId);

        [ItemNotNull]
        Task<IEnumerable<PlaceModel>> GetPlaces(int hallId);

        [ItemNotNull]
        Task<IEnumerable<HallSchemeModel>> GetHallScheme(int hallId);
    }
}
