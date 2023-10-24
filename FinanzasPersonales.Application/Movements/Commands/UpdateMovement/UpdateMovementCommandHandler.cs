using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Application.Movements.Common;
using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.ValueObjects;
using MediatR;

namespace FinanzasPersonales.Application.Movements.Commands.UpdateMovement;

public class UpdateMovementCommandHandler : IRequestHandler<UpdateMovementCommand, MovementResult>
{
    private readonly IMovementRepository _movementRepository;
    private readonly IAccountRepository _accountRepository;

    public UpdateMovementCommandHandler(IMovementRepository movementRepository, IAccountRepository accountRepository)
    {
        _movementRepository = movementRepository;
        _accountRepository = accountRepository;
    }

    public async Task<MovementResult> Handle(UpdateMovementCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var movement = _movementRepository.GetMovementById(request.Id);

        if (movement is null)
        {
            throw new Exception("El movimiento no existe");
        }

        var account = _accountRepository.GetAccountById(movement.AccountId.Value);

        if (account is null)
        {
            throw new Exception("La cuenta no existe");
        }


        movement.Update(
            request.Description,
            Amount.Create(request.Amount),
            request.Type,
            CategoryId.Create(request.CategoryId),
            AccountId.Create(request.AccountId),
            request.CreatedDate
        );

        _movementRepository.Update(movement);

        return new MovementResult(movement);

    }
}