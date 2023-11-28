using ExpenseControl.Domain.Services.Requests;
using ExpenseControl.Domain.ValueObjects;

namespace ExpenseControl.Domain.Services.Interfaces.Services.Identity
{
    public interface IAuthService
    {
        public Task<UserToken> Login(LoginRequest loginRequest);
    }
}
