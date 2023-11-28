using ExpenseControl.Data.Repositories.Base;
using ExpenseControl.Data.Repositories.Interfaces;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Infra.Context;

namespace ExpenseControl.Data.Repositories
{
    public class ExpenseRepository : RepositoryBase<Expense>, IExpenseRepository
    {
        public ExpenseRepository(DatabaseContext context) : base(context) { }
    }
}
