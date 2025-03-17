using Microsoft.AspNetCore.Mvc;
using ShopManager.Presentation.API_v1.DataAnnotations;

namespace ShopManager.Presentation.API_v1.Controllers;

public partial class AuthController
{
    [HttpPost("signin")]
    public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
    {
        var result = await _authService.SignIn(request.Login, request.Password, Request.Headers["User-Agent"].ToString(), HttpContext.Connection.RemoteIpAddress?.ToString());
        if (!result.IsSuccess) return BadRequest();
        
        var res = result.Value;
        return new OkObjectResult(new
        {
            UserId = res.UserId,
            RefreshToken = res.RefreshToken,
            ActionToken = res.ActionToken
        });
    }
}