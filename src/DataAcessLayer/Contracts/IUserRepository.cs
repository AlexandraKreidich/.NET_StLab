using DataAcessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAcessLayer.Contracts
{
    public interface IUserRepository
    {
        int Register(UserReq userReq);
        UserResp GetUser([NotNull] string email);
    }
}