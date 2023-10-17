using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Application.Movements.Common;
using MediatR;

namespace FinanzasPersonales.Application.Movements.Queries;

public class GetMovementsByUserIdQueryHandler : IRequestHandler<GetMovementsByUserIdQuery, List<MovementResult>>
{
    private readonly IMovementRepository _movementRepository;

    public GetMovementsByUserIdQueryHandler(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public async Task<List<MovementResult>> Handle(GetMovementsByUserIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var movements = _movementRepository.GetMovementsByUserId(request.UserId);

        if(movements is null)
        {
            throw new Exception("No hay movimientos para el usuario");
        }

        return new List<MovementResult>(movements.Select(m => new MovementResult(m)));
    }
}