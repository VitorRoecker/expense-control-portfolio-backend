using ExpenseControl.Domain.Services.Requests;
using ExpenseControl.Domain.ValueObjects;

namespace ExpenseControl.Domain.Services.Interfaces.Services
{
    public interface IUserService
    {
        public Task<UserToken> CreateUser(CreateUserRequest userRequest);
    }
}
