using ExpenseControl.Application;
using ExpenseControl.Application.Interfaces;
using ExpenseControl.Domain.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.API.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class ExpenseController(IExpenseAppService _appService) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var result = _appService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }

        [HttpGet()]
        public IActionResult GetAll(string userId)
        {
            try
            {
                var result = _appService.GetAll(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }

        [HttpPost]
        public IActionResult Add(Requests.Expense request)
        {
            try
            {
                var result = _appService.Add(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }

        [HttpPut]
        public IActionResult Update(Guid expenseId, Requests.Expense request)
        {
            try
            {
                _appService.Update(expenseId, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid expenseId)
        {
            try
            {
                _appService.Delete(expenseId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }
    }
}
