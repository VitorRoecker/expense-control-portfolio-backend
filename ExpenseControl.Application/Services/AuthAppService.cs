using ExpenseControl.Application.Interfaces;
using ExpenseControl.Domain.Services.Interfaces.Services.Identity;

namespace ExpenseControl.Application.Services
{
    public class AuthAppService(IAuthService _authService) : IAuthAppService
    {
        public async Task<Responses.UserToken> Login(Requests.Login loginRequest)
            => await _authService.Login(loginRequest);
    }
}
