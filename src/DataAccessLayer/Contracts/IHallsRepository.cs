using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface IHallsRepository
    {
        [ItemCanBeNull]
        Task<HallDalDtoModel> GetHall(int id);

        Task<int> AddOrUpdateHall([NotNull] HallDalDtoModel hallDalDto);

        Task<int> AddOrUpdateHallScheme([NotNull] HallSchemeDalDtoModel hallSchemeDalDto);

        Task<int> AddOrUpdatePlace([NotNull] PlaceDalDtoModel placeDalDto);
    }
}
