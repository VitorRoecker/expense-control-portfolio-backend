using ExpenseControl.Application.Interfaces;
using ExpenseControl.Domain.Services.Interfaces.Services;

namespace ExpenseControl.Application.Services
{
    public class UserAppService(IUserService _userService) : IUserAppService
    {
        public async Task<Responses.UserToken> CreateUser(Requests.Register request)
        {
            var userToken = await _userService.CreateUser(request);
            return userToken;
        }

        public async Task DeleteUser(Guid request)
            => await _userService.DeleteUser(request);
    }
}
