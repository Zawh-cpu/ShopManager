using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using ShopManager.Presentation.API_v1.DataAnnotations;

namespace ShopManager.Presentation.API_v1.Controllers;

public partial class AuthController
{
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
    {
        var result = await _authService.SignUp(request.FirstName, request.LastName, request.PhoneNumber, request.Email, request.Login, request.Password, Request.Headers["User-Agent"].ToString(), HttpContext.Connection.RemoteIpAddress?.ToString());
        if (result.IsConflict())
        {
            return Conflict();
        }
        
        var res = result.Value;
        return new OkObjectResult(new
        {
            res.UserId,
            res.RefreshToken,
            res.ActionToken
        });
    }
}