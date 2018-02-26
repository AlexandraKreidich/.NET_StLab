﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using BusinessLayer.Models;
using DataAcessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IUserService
    {
        UserModel Login([NotNull] string email, [NotNull] string password);

        UserModel Register(RegisterUserModel user);
    }
}
