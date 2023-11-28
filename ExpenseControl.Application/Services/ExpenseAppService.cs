using ExpenseControl.Application.Interfaces;
using ExpenseControl.Application.ViewModels;
using ExpenseControl.Domain.Services.Interfaces.Services;

namespace ExpenseControl.Application.Services
{
    public class ExpenseAppService : IExpenseAppService
    {
        private readonly IExpenseService _service;

        public ExpenseAppService(IExpenseService service)
        {
            _service = service;
        }

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

        public void Add(ExpenseViewModel income)
            => _service.Add(income.CreateDomain());

        public void Update(ExpenseViewModel income)
            => _service.Update(income.ConvertToDomain());

        public void Delete(Guid id)
            => _service.Delete(id);
    }
}
