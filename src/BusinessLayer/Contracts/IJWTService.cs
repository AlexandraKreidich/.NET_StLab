using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Models;

namespace BusinessLayer.Contracts
{
    public interface IJWTService
    {
        string GenerateJwtToken(UserModel user);
    }
}
