using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Application.Movements.Common;
using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.MovementAggregate;
using MediatR;

namespace FinanzasPersonales.Application.Movements.Commands;

public class CreateMovementCommandHandler : IRequestHandler<CreateMovementCommand, MovementResult>
{
    private readonly IMovementRepository _movementRepository;
    private readonly IAccountRepository _accountRepository;

    public CreateMovementCommandHandler(IMovementRepository movementRepository, IAccountRepository accountRepository)
    {
        _movementRepository = movementRepository;
        _accountRepository = accountRepository;
    }

    public async Task<MovementResult> Handle(CreateMovementCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var movement = Movement.Create(
            request.Description,
            Amount.Create(request.Amount),
            request.Type,
            AccountId.Create(request.AccountId),
            CategoryId.Create(request.CategoryId),
            request.CreatedDate
        );

        _movementRepository.Add(movement);

        return new MovementResult(movement);
    }
}