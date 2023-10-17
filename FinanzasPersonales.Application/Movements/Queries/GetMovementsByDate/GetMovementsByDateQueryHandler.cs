using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Application.Movements.Common;
using MediatR;

namespace FinanzasPersonales.Application.Movements.Queries.GetMovementsByDate;

public class GetMovementsByDateQueryHandler: IRequestHandler<GetMovementsByDateQuery, List<MovementResult>>
{
    private readonly IMovementRepository _movementRepository;

    public GetMovementsByDateQueryHandler(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public async Task<List<MovementResult>> Handle(GetMovementsByDateQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var movements = _movementRepository.GetMovementsByDate(request.Month, request.UserId);

        if(movements is null)
        {
            return new List<MovementResult>();
        }
        return new List<MovementResult>(movements.Select(m => new MovementResult(m)));
    }
}