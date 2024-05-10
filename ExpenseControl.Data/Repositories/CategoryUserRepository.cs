using ExpenseControl.Data.Repositories.Base;
using ExpenseControl.Data.Repositories.Interfaces;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Infra.Context;

namespace ExpenseControl.Data.Repositories
{
    public class CategoryUserRepository(DatabaseContext context) : RepositoryBase<CategoryUser>(context), ICategoryUserRepository
    {
    }
}
