using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace DataAcessLayer.Models.DataTransferObjects
{
    public class UserResp
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
        public byte[] Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
