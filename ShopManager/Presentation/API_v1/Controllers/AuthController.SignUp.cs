using Microsoft.AspNetCore.Mvc;
using ShopManager.Infrastructure.Data.Entities;
using ShopManager.Presentation.API_v1.DataAnnotations;

namespace ShopManager.Presentation.API_v1.Controllers;

public partial class AuthController
{
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
    {
        var user = new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            Login = request.Login,
            Password = request.Password,
        };
        
        await _baseRepository.AddEntityAsync(user);
        
        var token = new Token()
        {
            TokenType = 
        }
        
        return new OkObjectResult(new
        {
            Id = user.Id
        });
    }
}