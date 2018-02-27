using System.ComponentModel.DataAnnotations;
using Common;
using JetBrains.Annotations;

namespace WebApi.Models.User
{
    public class ResponseModel
    {
        [Required]
        public int Id { get;}
        [Required]
        public UserRole Role { get;}
        [NotNull]
        public string FirstName { get;}
        [NotNull]
        public string LastName { get;}
        [NotNull]
        public string Email { get;}
        [NotNull]
        public string Token { get;}

        public ResponseModel(
            [Required] int id,
            [Required] UserRole role,
            [NotNull] string firstName,
            [NotNull] string lastName,
            [NotNull] string email,
            [NotNull] string token
        )
        {
            Id = id;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Token = token;
        }
    }
}
