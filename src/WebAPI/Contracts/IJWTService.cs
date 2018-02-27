using BusinessLayer.Models;

namespace WebAPI.Contracts
{
    public interface IJWTService
    {
        string GenerateJwtToken(UserModel user);
    }
}
