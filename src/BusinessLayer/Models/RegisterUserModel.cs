using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class RegisterUserModel
    {
        [NotNull]
        public string Email { get;}

        [NotNull]
        public string FirstName { get;}

        [NotNull]
        public string LastName { get;}

        [NotNull]
        public string Password { get;}


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
