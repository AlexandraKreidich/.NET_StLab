using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IHallsService
    {
        [ItemCanBeNull]
        Task<FullHallBlModel> GetHall(int id);

        [ItemCanBeNull]
        Task<FullHallBlModel> GetHallForSession(int hallId, int sessionId);

        [ItemNotNull]
        Task<FullHallBlModel> AddOrOrUpdateHall([NotNull] FullHallBlModel fullHallBl);
    }
}
