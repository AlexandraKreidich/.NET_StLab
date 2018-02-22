using System.Net;
using System.Text;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using Common;
using DataAcessLayer.Contracts;
using DataAcessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace BusinessLayer.Services
{
    [UsedImplicitly]
    public class UserService : IUserService
    {
        [NotNull] private readonly IUserRepository _userRepository;

        public UserService([NotNull] IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public HttpStatusCode Login([NotNull] string email, [NotNull] string password)
        {
            UserResp user = _userRepository.GetUser(email);

            if (user == null)
            {
                // no user with this email
                return HttpStatusCode.NotFound;
            }

            if (CryptoService.GetHash(password, user.Salt).PasswordHash.Equals(user.PasswordHash))
            {
                return HttpStatusCode.NoContent;
            }
            else
            {
                // wrong password
                return HttpStatusCode.Unauthorized;
            }
        }

        public UserModel Register(RegisterModel regModel)
        {
            if (_userRepository.GetUser(regModel.Email) != null)
            {
                // error, user with this email already exist
                return null;
            }

            PasswordObject data = CryptoService.GetHash(regModel.Password);

            UserReq userToRegistrate = new UserReq()
            {
                Email = regModel.Email,
                FirstName = regModel.FirstName,
                LastName = regModel.LastName,
                PasswordHash = data.PasswordHash,
                Role = UserRole.User,
                Salt = data.Salt
            };

            int userId = _userRepository.Register(userToRegistrate);

            UserModel newUser = new UserModel()
            {
                Email = userToRegistrate.Email,
                Id = userId,
                FirstName = userToRegistrate.FirstName,
                LastName = userToRegistrate.LastName,
                Role = userToRegistrate.Role
            };

            return newUser;
        }

    }
}