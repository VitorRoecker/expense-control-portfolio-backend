using ExpenseControl.Domain.Requests;
using ExpenseControl.Domain.ValueObjects;

namespace ExpenseControl.Domain.Interfaces.Services
{
    public interface IUserService
    {
        public Task<UserToken> CreateUser(CreateUserRequest userRequest);
    }
}
