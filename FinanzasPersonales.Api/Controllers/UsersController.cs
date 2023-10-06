using FinanzasPersonales.Application.Accounts.Commands.CreateAccount;
using FinanzasPersonales.Application.Authentication.Queries.GetUserById;
using FinanzasPersonales.Contracts.Accounts;
using FinanzasPersonales.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.Api.Controllers;

[ApiController]
[Route("users")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    public UsersController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        var command = _mapper.Map<GetUserByIdQuery>(userId);

        var getUserResult = await _mediator.Send(command);

        var response = _mapper.Map<UserResponse>(getUserResult);

        return Ok(response);
    }
}