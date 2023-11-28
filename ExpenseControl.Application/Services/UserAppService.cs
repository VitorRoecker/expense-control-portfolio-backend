using ExpenseControl.Application.Interfaces;
using ExpenseControl.Application.ViewModels;
using ExpenseControl.Domain.Services.Interfaces.Services;
using ExpenseControl.Domain.Services.Requests;

namespace ExpenseControl.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private IUserService _userService;

        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserTokenViewModel> CreateUser(CreateUserRequest createUserRequest)
        {
            var userToken = await _userService.CreateUser(createUserRequest);
            return new UserTokenViewModel().ConvertToViewModel(userToken);
        }
    }
}
