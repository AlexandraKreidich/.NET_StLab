using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface IHallsRepository
    {
        [ItemCanBeNull]
        Task<HallModel> GetHall(int id);

        Task<int> AddOrUpdateHall([NotNull] HallModel hall);

        Task<int> AddOrUpdateHallScheme([NotNull] HallSchemeModel hallScheme);


        Task<int> AddOrUpdatePlace([NotNull] PlaceModel place);
    }
}
