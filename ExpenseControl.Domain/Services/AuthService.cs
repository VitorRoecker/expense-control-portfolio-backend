using ExpenseControl.Domain.Exceptions;
using ExpenseControl.Domain.Interfaces.Services;
using ExpenseControl.Domain.Requests;
using ExpenseControl.Domain.ValueObjects;
using ExpenseControl.Infra.Identity;
using Microsoft.AspNetCore.Identity;

namespace ExpenseControl.Domain.Services
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
            if (!await _userManager.CheckPasswordAsync(await _userManager.FindByEmailAsync(loginRequest.Email), loginRequest.Password))
                throw new ExpenseControlException("Login inválido.");

            return _jwtService.BuildToken(loginRequest.Email!);
        }
    }
}