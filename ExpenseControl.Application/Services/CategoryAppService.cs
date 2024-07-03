using ExpenseControl.Application.Interfaces;
using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Domain.Enumerables;
using ExpenseControl.Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace ExpenseControl.Application.Services
{
    public class CategoryAppService(ICategoryService service, UserManager<User> userManager) : ICategoryAppService
    {
        private readonly ICategoryService _service = service;
        private readonly UserManager<User> _userManager = userManager;

        public async Task<Responses.Identifier> Add(Requests.Category request)
        {
            var hasWithName = _service.GetAll().Where(x => x.UserId == request.UserId).Any(x => x.Name == request.Name);

            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                throw new Exception("Usuário não encontrado.");

            if (hasWithName)
                throw new Exception("Categoria ja cadastrada com este nome.");

            return new(_service.Add(request).Id);
        }

        public void Delete(Guid id)
        {
            var entity = _service.GetById(id) ?? throw new Exception("Categoria não encontrada.");
            _service.Delete(entity);
        }

        public IEnumerable<Responses.Category> GetAll(string UserId)
        {
            var categories = _service.GetAll().Where(x => x.UserId == UserId) ?? throw new Exception("Nenhuma categoria cadastrada.");

            return categories.Select(x => (Responses.Category)x).ToList();
        }

        public Responses.Category GetById(Guid id)
            => _service.GetById(id) ?? throw new Exception("Categoria não encontrada.");

        public void Update(Guid categoryId, Requests.Category request)
        {
            var category = _service.GetById(categoryId) ?? throw new Exception("Categoria não encontrada.");

            category.Name = request.Name;
            category.Description = request.Description;
            category.Type = (CategoryTypeEnum)request.Type;

            _service.Update(category);
        }
    }
}
