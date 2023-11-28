using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Services.Interfaces.Repositories.Base;

namespace ExpenseControl.Data.Repositories.Interfaces
{
    public interface IExpenseRepository : IRepositoryBase<Expense>
    {
    }
}
