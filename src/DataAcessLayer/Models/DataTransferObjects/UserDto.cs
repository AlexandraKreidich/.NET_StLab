using Common;

namespace DataAcessLayer.Models.DataTransferObjects
{
    public struct UserDto
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
        public string Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
