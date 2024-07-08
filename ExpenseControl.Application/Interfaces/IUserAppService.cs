namespace ExpenseControl.Application.Interfaces
{
    public interface IUserAppService
    {
        public Task<Responses.UserToken> CreateUser(Requests.Register request);
        public Task DeleteUser(Guid request);
    }
}
