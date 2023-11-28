using ExpenseControl.Domain.Services.Interfaces.Services.Identity;
using ExpenseControl.Domain.ValueObjects;
using ExpenseControl.Infra.External_Dependence;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenseControl.Domain.Services.Services.Identity
{
    public class JwtService : IJwtService
    {
        private readonly AppSettings _appSettings;

        public JwtService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public UserToken BuildToken(string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT!.Key!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
