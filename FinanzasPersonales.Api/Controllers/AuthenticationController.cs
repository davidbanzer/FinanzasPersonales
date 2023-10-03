using Microsoft.AspNetCore.Mvc;
using FinanzasPersonales.Contracts.Authentication;
using MediatR;
using FinanzasPersonales.Application.Authentication.Commands.Register;
using FinanzasPersonales.Application.Authentication.Common;
using FinanzasPersonales.Application.Authentication.Queries.Login;
using MapsterMapper;

namespace FinanzasPersonales.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
  private readonly ISender _mediator;
  private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]

  public async Task<IActionResult> Register(RegisterRequest request)
  {
    var command = _mapper.Map<RegisterCommand>(request);
    
    var authResult = await _mediator.Send(command);

    var response = _mapper.Map<AuthenticationResponse>(authResult); // aqui falla

    return Ok(response);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginRequest request)
  {
    var query = _mapper.Map<LoginQuery>(request);
    var authResult = await _mediator.Send(query);

    var response = _mapper.Map<AuthenticationResponse>(authResult);

    return Ok(response);
  }
}