using Microsoft.AspNetCore.Mvc;
using FinanzasPersonales.Contracts.Authentication;
using FinanzasPersonales.Application.Services.Authentication;
using FinanzasPersonales.Application.Services.Authentication.Commands;
using FinanzasPersonales.Application.Services.Authentication.Queries;

namespace FinanzasPersonales.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    public AuthenticationController(
      IAuthenticationCommandService authenticationCommandService, 
      IAuthenticationQueryService authenticationQueryService)
    {
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
    }
    private readonly IAuthenticationCommandService _authenticationCommandService;
  private readonly IAuthenticationQueryService _authenticationQueryService;
  [HttpPost("register")]

  public IActionResult Register(RegisterRequest request)
  {
    var authResult = _authenticationCommandService.Register(
      request.FirstName,
      request.LastName,
      request.Email,
      request.Password
    );

    var response = new AuthenticationResponse(
      authResult.User.Id,
      authResult.User.FirstName,
      authResult.User.LastName,
      authResult.User.Email,
      authResult.Token
    );
    
    return Ok(response);
  }

  [HttpPost("login")]
  public IActionResult Login(LoginRequest request)
  {
    var authResult = _authenticationQueryService.Login(
      request.Email,
      request.Password
    );

    var response = new AuthenticationResponse(
      authResult.User.Id,
      authResult.User.FirstName,
      authResult.User.LastName,
      authResult.User.Email,
      authResult.Token
    );

    return Ok(response);
  }
}