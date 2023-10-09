using ExpenseControl.Domain.Exceptions;
using ExpenseControl.Domain.Interfaces.Services;
using ExpenseControl.Domain.Requests;
using ExpenseControl.Domain.ValueObjects;
using ExpenseControl.Infra.Identity;
using Microsoft.AspNetCore.Identity;

namespace ExpenseControl.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public UserService(UserManager<User> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<UserToken> CreateUser(CreateUserRequest userRequest)
        {
            var user = new User
            {
                UserName = userRequest.Name,
                Email = userRequest.Email,
                PhoneNumber = userRequest.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, userRequest.Password);

            if (!result.Succeeded)
                throw new ExpenseControlException($"Erro ao registrar usuário: {result.Errors}");

            return _jwtService.BuildToken(user.Email!);
        }
    }
}
