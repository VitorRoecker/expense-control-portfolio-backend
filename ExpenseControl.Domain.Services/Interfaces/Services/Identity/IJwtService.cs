using ExpenseControl.Domain.ValueObjects;

namespace ExpenseControl.Domain.Services.Interfaces.Services.Identity
{
    public interface IJwtService
    {
        UserToken BuildToken(string email);
    }
}
