using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Application.Movements.Common;
using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.MovemenAggregate;
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
        // Si es de tipo ingreso, crear movimiento sin validación
        if (request.Type == "Ingreso")
        {
            var movementIncome = Movement.Create(
                request.Description,
                Amount.Create(request.Amount),
                request.Type,
                AccountId.Create(request.AccountId),
                CategoryId.Create(request.CategoryId)
            );

            _movementRepository.Add(movementIncome);

            return new MovementResult(movementIncome);
        }
        else if (request.Type == "Egreso")
        {
            // Verificar que tenga suficiente saldo, para eso se debe obtener el saldo de la cuenta
            var account = _accountRepository.GetAccountById(request.AccountId);

            if (account == null)
            {
                throw new Exception("La cuenta no existe");
            }

            // obtener todos los movimientos de esa cuenta y sumarlos o restarlos
            var movements = _movementRepository.GetMovementsByAccountId(request.AccountId);

            if (movements == null)
            {
                throw new Exception("La cuenta no tiene movimientos");
            }

            decimal total = 0.0m;

            foreach (var movement in movements)
            {
                if (movement.Type == "Ingreso")
                {
                    total += movement.Amount.Value;
                }
                else if (movement.Type == "Egreso")
                {
                    total -= movement.Amount.Value;
                }
            }

            if (total < request.Amount)
            {
                throw new Exception("No tiene suficiente saldo");
            }

            // Si tiene suficiente saldo, crear movimiento

            var movementExpense = Movement.Create(
                request.Description,
                Amount.Create(request.Amount),
                request.Type,
                AccountId.Create(request.AccountId),
                CategoryId.Create(request.CategoryId)
            );

            _movementRepository.Add(movementExpense);

            return new MovementResult(movementExpense);
        }
        else
        {
            throw new Exception("El tipo de movimiento no es válido");
        }

    }
}