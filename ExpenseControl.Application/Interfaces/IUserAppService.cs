namespace ExpenseControl.Application.Interfaces
{
    public interface IUserAppService
    {
        public Task<Responses.UserToken> CreateUser(Requests.CreateUser createUserRequest);
    }
}
