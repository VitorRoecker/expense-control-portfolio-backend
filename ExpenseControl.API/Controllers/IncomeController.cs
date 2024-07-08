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
    public class IncomeController(IIncomeAppService _appService) : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
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
        public async Task<IActionResult> Add(Requests.Income request)
        {
            try
            {
                var result = await _appService.Add(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }

        [HttpPut]
        public IActionResult Update(Guid incomeId, Requests.Income request)
        {
            try
            {
                _appService.Update(incomeId, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid incomeId)
        {
            try
            {
                _appService.Delete(incomeId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }
    }
}
