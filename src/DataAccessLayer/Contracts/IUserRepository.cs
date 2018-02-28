﻿using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface IUserRepository
    {
        [NotNull]
        Task<int> Register(UserRequest userRequest);
        [ItemCanBeNull]
        Task<UserResponse> GetUser([NotNull] string email);
    }
}