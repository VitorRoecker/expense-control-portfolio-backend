using ExpenseControl.Application.Interfaces;
using ExpenseControl.Domain.Services.Interfaces.Services;

namespace ExpenseControl.Application.Services
{
    public class UserAppService(IUserService _userService) : IUserAppService
    {
        public async Task<Responses.UserToken> CreateUser(Requests.CreateUser createUserRequest)
        {
            var userToken = await _userService.CreateUser(createUserRequest);
            return userToken;
        }
    }
}
