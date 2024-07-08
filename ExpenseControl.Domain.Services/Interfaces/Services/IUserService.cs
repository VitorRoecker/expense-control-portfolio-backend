using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Domain.Services.Interfaces.Services
{
    public interface IUserService
    {
        public Task<UserToken> CreateUser(Requests.CreateUser request);
        public Task DeleteUser(Requests.DeleteUser request);
    }
}
