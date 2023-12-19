using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NewProductManagement.Models;

namespace NewProductManagement.Services;

public class AuthenticationService
{
    public string GenerateJwtToken(string username, string password)
    {
        if (IsValidUser(username, password))
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your-secret-key-that-is-at-least-128-bits-long");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var writeToken = tokenHandler.WriteToken(token);
            TokenManager.SetToken(writeToken);
            
            return writeToken;
        }

        return null;
    }

    private bool IsValidUser(string username, string password)
    {
        // Gerçek uygulamalarda daha güvenli bir kullanıcı doğrulama yapılmalıdır
        return username == "user1" && password == "pass1";
    }
}