using ExpenseControl.Application.Interfaces;
using ExpenseControl.Application.ViewModels;
using ExpenseControl.Domain.Services.Interfaces.Services.Identity;
using ExpenseControl.Domain.Services.Requests;

namespace ExpenseControl.Application.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IAuthService _authService;

        public AuthAppService(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<UserTokenViewModel> Login(LoginRequest loginRequest)
        {
            var userToken = await _authService.Login(loginRequest);
            return new UserTokenViewModel().ConvertToViewModel(userToken);
        }
    }
}
