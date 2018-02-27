using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using DataAcessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IUserService
    {
        [ItemNotNull]
        Task<UserModel> Login([NotNull] string email, [NotNull] string password);

        UserModel Register(RegisterUserModel user);
    }
}
