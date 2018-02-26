using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class RegisterUserModel
    {
        [NotNull]
        public string Email { get; set; }

        [NotNull]
        public string FirstName { get; set; }

        [NotNull]
        public string LastName { get; set; }

        [NotNull]
        public string Password { get; set; }


        public RegisterUserModel(
            [NotNull] string email,
            [NotNull] string firstName,
            [NotNull] string lastName,
            [NotNull] string password
        )
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }
}
