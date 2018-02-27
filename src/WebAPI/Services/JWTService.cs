using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLayer.Models;
using Common;
using JetBrains.Annotations;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Contracts;

namespace WebAPI.Services
{
    public class JWTService : IJWTService
    {
        [NotNull]
        private readonly IWebAPISettings _settings;

        public JWTService([NotNull] IWebAPISettings settings)
        {
            _settings = settings;
        }

        public string GenerateJwtToken(UserModel user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, UserRole.User.ToString(), UserRole.Admin.ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JWTKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expires = DateTime.Now.AddDays(Convert.ToDouble(_settings.JWTExpireDays));

            JwtSecurityToken token = new JwtSecurityToken(
                _settings.JWTIssuer,
                _settings.JWTIssuer,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
