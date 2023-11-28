using ExpenseControl.Application.Interfaces;
using ExpenseControl.Domain.Services.Interfaces.Services;

namespace ExpenseControl.Application.Services
{
    public class CategoryUserAppService : ICategoryUserAppService
    {
        private readonly ICategoryUserService _service;

        public CategoryUserAppService(ICategoryUserService service)
        {
            _service = service;
        }
    }
}
