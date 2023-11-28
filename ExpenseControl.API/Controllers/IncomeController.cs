using ExpenseControl.Application.Interfaces;
using ExpenseControl.Application.ViewModels;
using ExpenseControl.Domain.Services.Requests.Income;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.API.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeAppService _appService;

        public IncomeController(IIncomeAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _appService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _appService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(CreateIncomeRequest request)
        {
            try
            {
                var viewModel = new IncomeViewModel
                {
                    Amount = request.Amount,
                    CategoryId = request.CategoryId,
                    Description = request.Description,
                    EntryDate = request.EntryDate,
                    Type = request.Type,
                    UserId = request.UserId,
                };

                _appService.Add(viewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(IncomeViewModel category)
        {
            try
            {
                _appService.Update(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
