using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiAuth.Models;
using Microsoft.IdentityModel.Tokens;

namespace ApiAuth.Services
{
    public static class TokenService
    {
        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user.UserName), new Claim(ClaimTypes.Role, user.Role) }),
                Expires = DateTime.UtcNow.AddHours(2),//It specifies the duration of the generated token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            //It generates the token based on the tokenDescriptor informations            
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}