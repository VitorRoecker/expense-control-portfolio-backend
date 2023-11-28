using ExpenseControl.Application.Interfaces;
using ExpenseControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.API.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseAppService _appService;

        public ExpenseController(IExpenseAppService appService)
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
        public IActionResult Add(ExpenseViewModel category)
        {
            try
            {
                _appService.Add(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(ExpenseViewModel category)
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
