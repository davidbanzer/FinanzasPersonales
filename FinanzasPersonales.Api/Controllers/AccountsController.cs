using FinanzasPersonales.Application.Accounts.Commands.CreateAccount;
using FinanzasPersonales.Contracts.Accounts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.Api.Controllers;

[ApiController]
[Route("accounts")]
[Authorize]
public class AccountsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    public AccountsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet("list")]
    public IActionResult ListAccounts()
    {
        return Ok(Array.Empty<string>());
    }

    [HttpGet("list/{userId}")]
    public IActionResult ListAccountsByUserId(Guid userId)
    {
        return Ok(Array.Empty<string>());
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> CreateAccount(CreateAccountRequest request, Guid userId)
    {
        var command = _mapper.Map<CreateAccountCommand>((request, userId));

        var createAccountResult = await _mediator.Send(command);

        var response = _mapper.Map<AccountResponse>(createAccountResult);

        return Ok(response);
    }
}