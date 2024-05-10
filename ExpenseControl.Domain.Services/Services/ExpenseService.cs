using ExpenseControl.Data.Repositories.Interfaces;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Services.Interfaces.Services;
using ExpenseControl.Domain.Services.Services.Base;

namespace ExpenseControl.Domain.Services.Services
{
    public class ExpenseService(IExpenseRepository repository) : ServiceBase<Expense, IExpenseRepository>(repository), IExpenseService
    {
    }
}
