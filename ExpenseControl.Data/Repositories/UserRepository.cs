using ExpenseControl.Data.Repositories.Base;
using ExpenseControl.Data.Repositories.Interfaces;
using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Infra.Context;

namespace ExpenseControl.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }
    }
}
