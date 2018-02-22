using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace BusinessLayer.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
