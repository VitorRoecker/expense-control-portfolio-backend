using ExpenseControl.Application.Interfaces;
using ExpenseControl.Domain.Services.Interfaces.Services;

namespace ExpenseControl.Application.Services
{
    public class CategoryUserAppService(ICategoryUserService _service) : ICategoryUserAppService
    {
    }
}
