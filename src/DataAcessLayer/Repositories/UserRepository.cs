using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper;
using DataAcessLayer.Contracts;
using DataAcessLayer.Models.DataTransferObjects;
using DataAcessLayer.Models.Entities;
using JetBrains.Annotations;

namespace DataAcessLayer.Repositories
{
    internal class UserRepository : IUserRepository
    {
        [NotNull]
        private readonly IDalSettings _settings;


        public UserRepository([NotNull] IDalSettings settings)
        {
            _settings = settings;
        }


        public UserDto GetUser([NotNull] string email)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                User user = connection.QuerySingleOrDefault<User>(
                    "GetUser",
                    new { Email = email },
                    commandType: CommandType.StoredProcedure);

                return Mapper.Map<UserDto>(user);
            }
        }
    }
}
