using Microsoft.AspNetCore.Mvc;
using FinanzasPersonales.Contracts.Authentication;
using FinanzasPersonales.Application.Services.Authentication;

namespace FinanzasPersonales.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
  public AuthenticationController(IAuthenticationService authenticationService)
  {
    _authenticationService = authenticationService;
  }
  private readonly IAuthenticationService _authenticationService;
  [HttpPost("register")]

  public IActionResult Register(RegisterRequest request)
  {
    var authResult = _authenticationService.Register(
      request.FirstName,
      request.LastName,
      request.Email,
      request.Password
    );

    var response = new AuthenticationResponse(
      authResult.Id,
      authResult.FirstName,
      authResult.LastName,
      authResult.Email,
      authResult.Token
    );
    
    return Ok(response);
  }

  [HttpPost("login")]
  public IActionResult Login(LoginRequest request)
  {
    var authResult = _authenticationService.Login(
      request.Email,
      request.Password
    );

    var response = new AuthenticationResponse(
      authResult.Id,
      authResult.FirstName,
      authResult.LastName,
      authResult.Email,
      authResult.Token
    );

    return Ok(response);
  }
}