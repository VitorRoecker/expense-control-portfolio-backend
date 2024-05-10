using ExpenseControl.Application.Interfaces;
using ExpenseControl.Application.ViewModels;
using ExpenseControl.Domain.Services.Interfaces.Services;

namespace ExpenseControl.Application.Services
{
    public class IncomeAppService(IIncomeService _service) : IIncomeAppService
    {
        public async Task<IncomeViewModel> GetById(Guid id)
        {
            var entity = await _service.GetById(id) ?? throw new Exception("Income not found");

            return new IncomeViewModel().ConvertToViewModel(entity);
        }

        public async Task<List<IncomeViewModel>> GetAll()
        {
            var result = await _service.GetAll();

            return result.Select(x => new IncomeViewModel().ConvertToViewModel(x)).ToList();
        }

        public void Add(IncomeViewModel income)
            => _service.Add(income.CreateDomain());

        public void Update(IncomeViewModel income)
            => _service.Update(income.ConvertToDomain());

        public void Delete(Guid id)
            => _service.Delete(id);
    }
}
