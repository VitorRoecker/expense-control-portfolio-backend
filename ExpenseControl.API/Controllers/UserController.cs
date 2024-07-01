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
    public class UserController(IUserAppService _userAppService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(Requests.CreateUser createUserRequest)
        {
            try
            {
                var result = await _userAppService.CreateUser(createUserRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }
    }
}
