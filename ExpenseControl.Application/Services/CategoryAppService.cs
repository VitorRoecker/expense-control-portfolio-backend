using ExpenseControl.Application.Interfaces;
using ExpenseControl.Application.ViewModels;
using ExpenseControl.Domain.Services.Interfaces.Services;

namespace ExpenseControl.Application.Services
{
    public class CategoryAppService(ICategoryService _service) : ICategoryAppService
    {
        public async Task<CategoryViewModel> GetById(Guid id)
        {
            var entity = await _service.GetById(id) ?? throw new Exception("Category not found");

            return new CategoryViewModel().ConvertToViewModel(entity);
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            var result = await _service.GetAll();

            return result.Select(x => new CategoryViewModel().ConvertToViewModel(x)).ToList();
        }

        public void Add(CategoryViewModel income)
            => _service.Add(income.CreateDomain());

        public void Update(CategoryViewModel income)
            => _service.Update(income.ConvertToDomain());

        public void Delete(Guid id)
            => _service.Delete(id);
    }
}
