using ExpenseControl.Application.ViewModels;
using ExpenseControl.Domain.Requests;

namespace ExpenseControl.Application.Interfaces
{
    public interface IAuthAppService
    {
        public Task<UserTokenViewModel> Login(LoginRequest loginRequest);
    }
}
