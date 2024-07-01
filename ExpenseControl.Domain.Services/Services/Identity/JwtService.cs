using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Domain.Services.Interfaces.Services.Identity;
using ExpenseControl.Infra.External_Dependence;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenseControl.Domain.Services.Services.Identity
{
    public class JwtService(IOptions<AppSettings> options) : IJwtService
    {
        private readonly AppSettings _appSettings = options.Value;

        public UserToken BuildToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                new Claim(JwtRegisteredClaimNames.Name, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT!.Key!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(99);

            JwtSecurityToken token = new(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new()
            {
                UserId = Guid.Parse(user.Id),
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
