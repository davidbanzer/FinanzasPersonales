using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Application.Movements.Common;
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
        var movementBeforeUpdate = movement;


        var account = _accountRepository.GetAccountById(movement.AccountId.Value);

        if (account is null)
        {
            throw new Exception("La cuenta no existe");
        }


        // Si el movimiento es de tipo ingreso, se suma al balance de la cuenta
        if (request.Type == "Ingreso")
        {
            movement.Update(
                request.Description,
                Amount.Create(request.Amount),
                request.Type,
                CategoryId.Create(request.CategoryId)
            );

            _movementRepository.Update(movement);

            return new MovementResult(movement);

        }
        else if (request.Type == "Egreso")
        {
            movement.Update(
                request.Description,
                Amount.Create(request.Amount),
                request.Type,
                CategoryId.Create(request.CategoryId)
            );

            _movementRepository.Update(movement);

            var balance = _accountRepository.GetBalanceByAccountId(account.Id.Value);
            
            if (balance < 0)
            {
                movement.Update(
                    movementBeforeUpdate.Description,
                    movementBeforeUpdate.Amount,
                    movementBeforeUpdate.Type,
                    movementBeforeUpdate.CategoryId
                );

                _movementRepository.Update(movement);

                throw new Exception("El balance de la cuenta no puede ser menor a 0");
            }

            return new MovementResult(movement);

        }
        else
        {
            throw new Exception("El tipo de movimiento no es válido");
        }

    }
}