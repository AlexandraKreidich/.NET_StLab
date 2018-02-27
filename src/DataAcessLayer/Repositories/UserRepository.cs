using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using DataAcessLayer.Contracts;
using DataAcessLayer.Models.DataTransferObjects;
using DataAcessLayer.Models.Entities;
using JetBrains.Annotations;

namespace DataAcessLayer.Repositories
{
    [UsedImplicitly]
    internal class UserRepository : IUserRepository
    {
        [NotNull]
        private readonly IDalSettings _settings;


        public UserRepository([NotNull] IDalSettings settings)
        {
            _settings = settings;
        }


        public Task<UserResp> GetUser([NotNull] string email)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                User user = connection.QuerySingleOrDefault<User>(
                    "GetUser",
                    new { Email = email },
                    commandType: CommandType.StoredProcedure);

                return null; //Mapper.Map<UserResp>(user);
            }
        }

        public int Register(UserReq userReq)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = connection.ExecuteScalar<int>(
                    "AddUser",
                    new {
                        Email = userReq.Email,
                        FirstName = userReq.FirstName,
                        LastName = userReq.LastName,
                        UserRole = userReq.Role.ToString(),
                        PasswordHash = userReq.PasswordHash,
                        Salt = userReq.Salt
                    },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }
    }
}
