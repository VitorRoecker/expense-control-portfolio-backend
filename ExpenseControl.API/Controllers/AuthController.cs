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
    public class AuthController(IAuthAppService _authAppService) : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Requests.Login loginRequest)
        {
            try
            {
                var result = await _authAppService.Login(loginRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }
    }
}
