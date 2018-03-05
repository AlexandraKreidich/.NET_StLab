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

        [ItemNotNull]
        Task<IEnumerable<HallResponse>> GetHalls(int cinemaId);

        [ItemNotNull]
        Task<IEnumerable<PlaceResponse>> GetPlaces(int hallId);

        [ItemNotNull]
        Task<IEnumerable<HallSchemeResponse>> GetHallScheme(int hallId);
    }
}
