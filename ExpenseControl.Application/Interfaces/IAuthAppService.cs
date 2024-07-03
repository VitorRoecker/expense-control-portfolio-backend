namespace ExpenseControl.Application.Interfaces
{
    public interface IAuthAppService
    {
        public Task<Responses.UserToken> Login(Requests.Login loginRequest);
    }
}
