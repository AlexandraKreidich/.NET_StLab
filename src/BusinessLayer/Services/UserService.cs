using BusinessLayer.Contracts;
using DataAcessLayer.Contracts;
using DataAcessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace BusinessLayer.Services
{
    internal class UserService : IUserService
    {
        [NotNull] private readonly IUserRepository _userRepository;

        public UserService([NotNull] IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto Login([NotNull] string email, [NotNull] string password)
        {
            var user = _userRepository.GetUser(email);
            return user;
        }
    }
}