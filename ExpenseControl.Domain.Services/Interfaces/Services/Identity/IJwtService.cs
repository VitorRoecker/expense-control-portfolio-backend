using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Entities.Identity;

namespace ExpenseControl.Domain.Services.Interfaces.Services.Identity
{
    public interface IJwtService
    {
        UserToken BuildToken(User user);
    }
}
