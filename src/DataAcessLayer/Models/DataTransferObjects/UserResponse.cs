using Common;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class UserResponse
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
        public byte[] Salt { get; set; }
        [NotNull]
        public string FirstName { get; set; }
        [NotNull]
        public string LastName { get; set; }
        public string Email { get; set; }
        [NotNull]
        public byte[] PasswordHash { get; set; }
    }
}
