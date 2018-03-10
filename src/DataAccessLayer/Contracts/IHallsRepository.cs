using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface IHallsRepository
    {
        [ItemCanBeNull]
        Task<HallModel> GetHall(int id);
        
        Task<int> AddOrUpdateHall(HallModel hall);

        [NotNull]
        Task<int> AddOrUpdateHallScheme(HallSchemeModel hallScheme);

        [NotNull]
        Task<int> AddOrUpdatePlace(PlaceModel place);
    }
}
