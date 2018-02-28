using System.ComponentModel.DataAnnotations;
using Common;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class UserModel
    {
        public int Id { get;}
        public UserRole Role { get;}
        [NotNull]
        public string FirstName { get;}
        [NotNull]
        public string LastName { get;}
        [NotNull]
        public string Email { get;}

        public UserModel(
            [Required] int id,
            [Required] UserRole role,
            [NotNull] string firstName,
            [NotNull] string lastName,
            [NotNull] string email
        )
        {
            Id = id;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
