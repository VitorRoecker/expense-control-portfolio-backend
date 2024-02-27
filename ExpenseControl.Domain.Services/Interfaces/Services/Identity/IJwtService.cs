using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Domain.ValueObjects;

namespace ExpenseControl.Domain.Services.Interfaces.Services.Identity
{
    public interface IJwtService
    {
        UserToken BuildToken(User user);
    }
}
