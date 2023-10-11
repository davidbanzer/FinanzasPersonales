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
            if (_accountRepository.GetBalanceByAccountId(request.AccountId) < request.Amount)
            {
                throw new Exception("No hay suficiente dinero en la cuenta para realizar el movimiento");
            }

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