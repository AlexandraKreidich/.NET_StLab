using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IHallsService
    {
        [ItemCanBeNull]
        Task<FullHallBlModel> GetHall(int id);

        [ItemNotNull]
        Task<FullHallBlModel> AddOrOrUpdateHall([NotNull] FullHallBlModel fullHallBl);
    }
}
