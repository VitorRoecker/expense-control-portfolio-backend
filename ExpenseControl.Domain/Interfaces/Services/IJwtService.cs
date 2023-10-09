using ExpenseControl.Domain.ValueObjects;

namespace ExpenseControl.Domain.Interfaces.Services
{
    public interface IJwtService
    {
        UserToken BuildToken(string email);
    }
}
