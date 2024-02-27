using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Domain.Exceptions;
using ExpenseControl.Domain.Services.Interfaces.Services.Identity;
using ExpenseControl.Domain.Services.Requests;
using ExpenseControl.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace ExpenseControl.Domain.Services.Services.Identity
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public AuthService(UserManager<User> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<UserToken> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.DocumentoFederal);

            if (!await _userManager.CheckPasswordAsync(user, loginRequest.Password))
                throw new ExpenseControlException("Login inválido.");

            return _jwtService.BuildToken(user);
        }
    }
}