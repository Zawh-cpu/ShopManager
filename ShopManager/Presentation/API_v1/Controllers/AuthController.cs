﻿using Microsoft.AspNetCore.Mvc;
using ShopManager.Core.Interfaces;

namespace ShopManager.Presentation.API_v1.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class AuthController : ControllerBase
{
    private readonly IBaseRepository _baseRepository;
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;

    public AuthController(IBaseRepository baseRepository, IAuthService authService, ITokenService tokenService)
    {
        _baseRepository = baseRepository;
        _authService = authService;
        _tokenService = tokenService;
    }
}