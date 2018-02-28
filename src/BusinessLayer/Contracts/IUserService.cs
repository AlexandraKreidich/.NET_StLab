using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IUserService
    {
        [ItemNotNull]
        Task<UserModel> Login([NotNull] string email, [NotNull] string password);
        [ItemNotNull]
        Task<UserModel> Register([NotNull] RegisterUserModel user);
    }
}
