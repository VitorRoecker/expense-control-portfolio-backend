using ExpenseControl.Application.Interfaces;
using ExpenseControl.Application.ViewModels;
using ExpenseControl.Domain.Services.Interfaces.Services.Identity;
using ExpenseControl.Domain.Services.Requests;

namespace ExpenseControl.Application.Services
{
    public class AuthAppService(IAuthService _authService) : IAuthAppService
    {
        public async Task<UserTokenViewModel> Login(LoginRequest loginRequest)
        {
            var userToken = await _authService.Login(loginRequest);
            return new UserTokenViewModel().ConvertToViewModel(userToken);
        }
    }
}
