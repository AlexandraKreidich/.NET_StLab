using System.Threading.Tasks;
using DataAcessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAcessLayer.Contracts
{
    public interface IUserRepository
    {
        int Register(UserReq userReq);
        Task<UserResp> GetUser([NotNull] string email);
    }
}