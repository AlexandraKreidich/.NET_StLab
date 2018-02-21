using System;
using System.Collections.Generic;
using System.Text;
using DataAcessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IUserService
    {
        UserDto GetUser([NotNull] string email, [NotNull] string password);
    }
}
