using ExpenseControl.Data.Repositories.Base;
using ExpenseControl.Data.Repositories.Interfaces;
using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Infra.Context;

namespace ExpenseControl.Data.Repositories
{
    public class UserRepository(DatabaseContext context) : RepositoryBase<User>(context), IUserRepository
    {
    }
}
