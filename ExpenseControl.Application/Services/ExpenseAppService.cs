using ExpenseControl.Application.Interfaces;
using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Domain.Enumerables;
using ExpenseControl.Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace ExpenseControl.Application.Services
{
    public class ExpenseAppService(IExpenseService _service,
                                   ICategoryService _categoryService,
                                   UserManager<User> _userManager) : IExpenseAppService
    {
        public Responses.Expense GetById(Guid id)
            => _service.GetById(id) ?? throw new Exception("Despesa não encontrado.");

        public IEnumerable<Responses.Expense> GetAll(string UserId)
        {
            var entities = _service.GetAll().Where(x => x.UserId == UserId) ?? throw new Exception("Nenhuma despesa cadastrada para esta conta.");

            return entities.Select(x => (Responses.Expense)x).ToList();
        }

        public async Task<Responses.Identifier> Add(Requests.Expense request)
        {
            var hasWithName = _service.GetAll().Where(x => x.UserId == request.UserId)
                                               .Any(x => x.Amount == request.Amount && x.Description == request.Description);

            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                throw new Exception("Usuário não encontrado.");

            var category = _categoryService.GetById(request.CategoryId);
            
            if (category is null)
                throw new Exception("Categoria não encontrada.");


            if (hasWithName)
                throw new Exception("Ja existe uma Despesa com este valor e descrição.");

            return new(_service.Add(request).Id);
        }

        public void Update(Guid expenseId, Requests.Expense request)
        {
            var entity = _service.GetById(expenseId) ?? throw new Exception("Despesa não encontrada.");

            var category = _categoryService.GetById(request.CategoryId) ?? throw new Exception("Categoria não encontrada");
            
            entity.Amount = request.Amount;
            entity.Description = request.Description;
            entity.Type = (TransactionTypeEnum)request.Type;
            entity.ExpirationDate = request.ExpirationDate;
            entity.CategoryId = category.Id;

            _service.Update(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _service.GetById(id) ?? throw new Exception("Despesa não encontrada.");
            _service.Delete(entity);
        }
    }
}
