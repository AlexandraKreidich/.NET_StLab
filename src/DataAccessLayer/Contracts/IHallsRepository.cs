using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using DataAccessLayer.Models.Entities;

namespace DataAccessLayer.Contracts
{
    public interface IHallsRepository
    {
        Task<HallModel> GetHall(int id);
    }
}
