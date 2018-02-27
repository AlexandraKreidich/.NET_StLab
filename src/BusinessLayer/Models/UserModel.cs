using Common;

namespace BusinessLayer.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
