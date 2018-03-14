using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IHallsService
    {
        [ItemCanBeNull]
        Task<HallModelForApi> GetHall(int id);

        [ItemNotNull]
        Task<HallModelForApi> AddOrOrUpdateHall(HallModelForApi hall);
    }
}
