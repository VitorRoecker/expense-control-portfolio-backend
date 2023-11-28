using ExpenseControl.Application.ViewModels;
using ExpenseControl.Domain.Services.Requests;

namespace ExpenseControl.Application.Interfaces
{
    public interface IAuthAppService
    {
        public Task<UserTokenViewModel> Login(LoginRequest loginRequest);
    }
}
