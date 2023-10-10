using FinanzasPersonales.Application.Movements.Commands;
using FinanzasPersonales.Contracts.Movements;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.Api.Controllers;

[ApiController]
[Route("movements")]
[Authorize]

public class MovementsController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public MovementsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovement(CreateMovementRequest request)
    {
        var command = _mapper.Map<CreateMovementCommand>(request);

        var createMovementResult = await _mediator.Send(command);

        var response = _mapper.Map<MovementResponse>(createMovementResult);

        return Ok(response);
    }
}