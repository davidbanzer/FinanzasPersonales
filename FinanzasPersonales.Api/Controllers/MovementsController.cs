using FinanzasPersonales.Application.Movements.Commands;
using FinanzasPersonales.Application.Movements.Commands.DeleteMovement;
using FinanzasPersonales.Application.Movements.Commands.UpdateMovement;
using FinanzasPersonales.Application.Movements.Queries;
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

    [HttpPut("{movementId}")]
    public async Task<IActionResult> UpdateMovement(UpdateMovementRequest request, Guid movementId)
    {
        var command = _mapper.Map<UpdateMovementCommand>((request, movementId));

        var updateMovementResult = await _mediator.Send(command);

        var response = _mapper.Map<MovementResponse>(updateMovementResult);

        return Ok(response);
    }

    [HttpDelete("{movementId}")]
    public async Task<IActionResult> DeleteMovement(Guid movementId)
    {
        var command = new DeleteMovementCommand(movementId);

        var deleteMovementResult = await _mediator.Send(command);

        return Ok(deleteMovementResult);
    }

    [HttpGet("all/{userId}")]
    public async Task<IActionResult> GetMovementsByUserId(Guid userId)
    {
        var query = new GetMovementsByUserIdQuery(userId);
        
        var movementsResult = await _mediator.Send(query);

        var response = _mapper.Map<IEnumerable<MovementResponse>>(movementsResult);

        return Ok(response);
    }
}