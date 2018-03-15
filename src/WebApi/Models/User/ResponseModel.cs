using Common;
using JetBrains.Annotations;

namespace WebApi.Models.User
{
    public class ResponseModel
    {
        public int Id { get;}

        public UserRole UserRole { get;}

        [NotNull]
        public string FirstName { get;}

        [NotNull]
        public string LastName { get;}

        [NotNull]
        public string Email { get;}

        [NotNull]
        public string Token { get;}

        public ResponseModel(
            int id,
            UserRole userRole,
            [NotNull] string firstName,
            [NotNull] string lastName,
            [NotNull] string email,
            [NotNull] string token
        )
        {
            Id = id;
            UserRole = userRole;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Token = token;
        }
    }
}
