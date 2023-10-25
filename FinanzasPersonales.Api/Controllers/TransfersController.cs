using FinanzasPersonales.Application.Transfers.Commands.CreateTransfer;
using FinanzasPersonales.Application.Transfers.Commands.DeleteTransfer;
using FinanzasPersonales.Application.Transfers.Queries.GetTransferByUserId;
using FinanzasPersonales.Contracts.Transfers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.Api.Controllers;


[ApiController]
[Route("transfers")]
[Authorize]

public class TransfersController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public TransfersController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransfer(CreateTransferRequest request)
    {
        var command = _mapper.Map<CreateTransferCommand>(request);

        var createTransferResult = await _mediator.Send(command);

        var response = _mapper.Map<TransferResponse>(createTransferResult);

        return Ok(response);
    }

    [HttpGet("all/{userId}")]
    public async Task<IActionResult> GetTransfersByUserId(Guid userId)
    {
        var query = _mapper.Map<GetTransfersByUserIdQuery>(userId);

        var getTransfersByUserIdResult = await _mediator.Send(query);

        var response = _mapper.Map<List<TransferResponse>>(getTransfersByUserIdResult);

        return Ok(response);
    }

    [HttpDelete("{transferId}")]
    public async Task<IActionResult> DeleteTransfer(Guid transferId)
    {
        var command = _mapper.Map<DeleteTransferCommand>(transferId);

        var deleteTransferResult = await _mediator.Send(command);

        return Ok(deleteTransferResult);
    }
}