using ExpenseControl.Application.Interfaces;
using ExpenseControl.Application.ViewModels;
using ExpenseControl.Domain.Services.Interfaces.Services;

namespace ExpenseControl.Application.Services
{
    public class ExpenseAppService(IExpenseService _service) : IExpenseAppService
    {
        public async Task<ExpenseViewModel> GetById(Guid id)
        {
            var entity = await _service.GetById(id) ?? throw new Exception("Expense not found");

            return new ExpenseViewModel().ConvertToViewModel(entity);
        }

        public async Task<List<ExpenseViewModel>> GetAll() 
        { 
            var result = await _service.GetAll();

            return result.Select(x => new ExpenseViewModel().ConvertToViewModel(x)).ToList();
        }

        public void Add(ExpenseViewModel expense)
            => _service.Add(expense.CreateDomain());

        public void Update(ExpenseViewModel expense)
            => _service.Update(expense.ConvertToDomain());

        public void Delete(Guid id)
            => _service.Delete(id);
    }
}
