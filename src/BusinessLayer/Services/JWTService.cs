using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAcessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer.Services
{
    public class JWTService : IJWTService
    {
        [NotNull]
        private readonly IBlSettings _settings;
        
        public JWTService([NotNull] IBlSettings settings)
        {
            _settings = settings;
        }
        
        public string GenerateJwtToken(UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JWTKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_settings.JWTExpireDays));

            var token = new JwtSecurityToken(
                _settings.JWTIssuer,
                _settings.JWTIssuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
