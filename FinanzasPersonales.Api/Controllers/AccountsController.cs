using FinanzasPersonales.Application.Accounts.Commands.CreateAccount;
using FinanzasPersonales.Application.Accounts.Commands.DeleteAccount;
using FinanzasPersonales.Application.Accounts.Commands.UpdateAccount;
using FinanzasPersonales.Application.Accounts.Queries.GetAccountsByUserId;
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

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetAccountsByUserId(Guid userId)
    {
        var query = _mapper.Map<GetAccountsByUserIdQuery>(userId);

        var accountsResult = await _mediator.Send(query);

        var response = _mapper.Map<List<AccountResponse>>(accountsResult);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAccount(CreateAccountRequest request)
    {
        var command = _mapper.Map<CreateAccountCommand>(request);

        var createAccountResult = await _mediator.Send(command);

        var response = _mapper.Map<AccountResponse>(createAccountResult);

        return Ok(response);
    }

    [HttpPut("{accountId}")]
    public async Task<IActionResult> UpdateAccount(UpdateAccountRequest request, Guid accountId)
    {
        var command = _mapper.Map<UpdateAccountCommand>((request, accountId));

        var updateAccountResult = await _mediator.Send(command);

        var response = _mapper.Map<AccountResponse>(updateAccountResult);

        return Ok(response);
    }

    [HttpDelete("{accountId}")]
    public async Task<IActionResult> DeleteAccount(Guid accountId)
    {
        var command = _mapper.Map<DeleteAccountCommand>(accountId);

        var deleteAccountResult = await _mediator.Send(command);

        return Ok(deleteAccountResult);
    }
}