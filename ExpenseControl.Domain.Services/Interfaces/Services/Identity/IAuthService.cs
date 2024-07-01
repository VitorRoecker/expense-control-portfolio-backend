using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Domain.Services.Interfaces.Services.Identity
{
    public interface IAuthService
    {
        public Task<UserToken> Login(Requests.Login loginRequest);
    }
}
