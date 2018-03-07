using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Contracts
{
    public interface IHallsService
    {
        Task<HallModelForApi> GetHall(int id);
    }
}
