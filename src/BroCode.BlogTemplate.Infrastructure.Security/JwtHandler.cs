using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BroCode.BlogTemplate.Infrastructure.Security
{
    public static class JwtHandler
    {
        public static string GenerateToken(string securityKey, string userName, int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKeyBytes = Encoding.ASCII.GetBytes(securityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(JwtRegisteredClaimNames.Sub, userId.ToString())
                }),
                Issuer = "BlogTemplate",
                Audience = "*",
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
         
            return tokenHandler.WriteToken(token);
        }
    }
}
