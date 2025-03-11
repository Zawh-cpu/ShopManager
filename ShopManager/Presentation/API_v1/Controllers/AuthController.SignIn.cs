using Microsoft.AspNetCore.Mvc;
using ShopManager.Presentation.API_v1.DataAnnotations;

namespace ShopManager.Presentation.API_v1.Controllers;

public partial class AuthController
{
    [HttpPost("signin")]
    public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
    {
        return new OkObjectResult(new
        {
            Email = request.Login,
            Password = request.Password
        });
    }
}