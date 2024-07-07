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
    public class CategoryController(ICategoryAppService _appService) : ControllerBase
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
        public IActionResult GetAll(string UserId)
        {
            try
            {
                var result = _appService.GetAll(UserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Requests.Category request)
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
        public IActionResult Update(Guid categoryId, Requests.Category request)
        {
            try
            {
                _appService.Update(categoryId, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid categoryId)
        {
            try
            {
                _appService.Delete(categoryId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }
    }
}
