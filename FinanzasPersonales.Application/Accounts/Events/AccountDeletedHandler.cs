using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.AccountAggregate.Events;
using MediatR;

namespace FinanzasPersonales.Application.Accounts.Events;

public class AccountDeletedHandler: INotificationHandler<AccountDeleted>
{
    private readonly IMovementRepository _movementRepository;

    public AccountDeletedHandler(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public Task Handle(AccountDeleted notification, CancellationToken cancellationToken)
    {
        
        // obtener todos los movimientos de la cuenta
        var movements = _movementRepository.GetMovementsByAccountId(notification.Account.Id.Value);
        
        if(movements is null)
        {
            return Task.CompletedTask;
        }
        // eliminar todos los movimientos de la cuenta
        foreach (var movement in movements)
        {
            _movementRepository.Delete(movement);
        }

        return Task.CompletedTask;
    }
}