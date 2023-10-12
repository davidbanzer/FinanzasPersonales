using FinanzasPersonales.Application.Transfers.Commands.CreateTransfer;
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
}