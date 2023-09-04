using Microsoft.IdentityModel.Tokens;
using SenorBarbero.IServices;
using SenorBarbero.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SenorBarbero.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                throw new ArgumentNullException(nameof(user));
            }

            Claim[] claims = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id),
                new Claim("LoginTimestamp", DateTime.UtcNow.ToString())
            };

            var symetricSecurityKey = _configuration["SymmetricSecurityKey"];
            if (symetricSecurityKey == null)
                throw new ApplicationException("symetricSecurityKey não informado nos secrets contidos no csproj da aplicação");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symetricSecurityKey));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
