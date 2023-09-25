using Microsoft.AspNetCore.Mvc;
using FinanzasPersonales.Contracts.Authentication;
using MediatR;
using FinanzasPersonales.Application.Authentication.Commands.Register;
using FinanzasPersonales.Application.Authentication.Common;
using FinanzasPersonales.Application.Authentication.Queries.Login;

namespace FinanzasPersonales.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
  private readonly ISender _mediator;
  
  public AuthenticationController(ISender mediator)
  {
    _mediator = mediator;
  }

  [HttpPost("register")]

  public async Task<IActionResult> Register(RegisterRequest request)
  {
    var command = new RegisterCommand(
      request.FirstName,
      request.LastName,
      request.Email,
      request.Password
    );
    
    var authResult = await _mediator.Send(command);

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
  public async Task<IActionResult> Login(LoginRequest request)
  {
    var query = new LoginQuery(
      request.Email,
      request.Password
    );
    var authResult = await _mediator.Send(query);

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