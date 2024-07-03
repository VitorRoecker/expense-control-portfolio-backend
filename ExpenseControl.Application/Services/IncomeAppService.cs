using ExpenseControl.Application.Interfaces;
using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Domain.Enumerables;
using ExpenseControl.Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace ExpenseControl.Application.Services
{
    public class IncomeAppService(IIncomeService _service,
                                  ICategoryService _categoryService,
                                  UserManager<User> _userManager) : IIncomeAppService
    {
        public Responses.Income GetById(Guid id)
            => _service.GetById(id) ?? throw new Exception("Renda não encontrado.");

        public IEnumerable<Responses.Income> GetAll(string UserId)
        {
            var entities = _service.GetAll().Where(x => x.UserId == UserId) ?? throw new Exception("Nenhuma renda cadastrada para esta conta.");

            return entities.Select(x => (Responses.Income)x).ToList();
        }

        public async Task<Responses.Identifier> Add(Requests.Income request)
        {
            var hasWithName = _service.GetAll().Where(x => x.UserId == request.UserId)
                                               .Any(x => x.Amount == request.Amount && x.Description == request.Description);

            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                throw new Exception("Usuário não encontrado.");

            var category = _categoryService.GetById(request.CategoryId);

            if (category is null)
                throw new Exception("Categoria não encontrada");


            if (hasWithName)
                throw new Exception("Ja existe uma renda com este valor e descrição.");

            return new(_service.Add(request).Id);
        }

        public void Update(Guid incomeId, Requests.Income request)
        {
            var entity = _service.GetById(incomeId) ?? throw new Exception("Gasto não encontrado");

            entity.Description = request.Description;
            entity.Type = (TransactionTypeEnum)request.Type;

            _service.Update(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _service.GetById(id) ?? throw new Exception("Gasto não encontrado.");
            _service.Delete(entity);
        }
    }
}
