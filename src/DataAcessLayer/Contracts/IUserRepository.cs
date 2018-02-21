using DataAcessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAcessLayer.Contracts
{
    public interface IUserRepository
    {
        UserDto GetUser([NotNull] string email);
    }
}