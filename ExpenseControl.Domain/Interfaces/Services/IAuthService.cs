using ExpenseControl.Domain.Requests;
using ExpenseControl.Domain.ValueObjects;

namespace ExpenseControl.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<UserToken> Login(LoginRequest loginRequest);
    }
}
