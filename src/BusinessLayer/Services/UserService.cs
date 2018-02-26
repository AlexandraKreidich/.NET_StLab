using System;
using System.Net;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using Common;
using Common.Extensions;
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

        public UserModel Login([NotNull] string email, [NotNull] string password)
        {
            email = email ?? throw new ArgumentNullException(nameof(email));
            password = password ?? throw new ArgumentNullException(nameof(password));

            UserResp user = _userRepository.GetUser(email);

            if (user == null)
            {
                // no user with this email
                return null;
            }

            byte[] passwordHash = CryptoService.GetHash(password, user.Salt).PasswordHash;

            // check if the password is right
            if (passwordHash.Select((b, i) => b == user.PasswordHash[i]).All(item => item))
            {
                UserModel userModel = new UserModel()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    LastName = user.LastName,
                    Role = user.Role
                };

                return userModel;
            }

            // wrong password
            return null;
        }

        public UserModel Register(RegisterUserModel regModel)
        {
            regModel.EnsureObjectPropertiesNotNull();

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