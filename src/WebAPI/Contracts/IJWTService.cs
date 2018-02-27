using BusinessLayer.Models;

namespace WebApi.Contracts
{
    public interface IJwtService
    {
        string GenerateJwtToken(UserModel user);
    }
}
