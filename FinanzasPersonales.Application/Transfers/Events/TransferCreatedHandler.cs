using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.MovementAggregate;
using FinanzasPersonales.Domain.TransferAggregate.Events;
using MediatR;

namespace FinanzasPersonales.Application.Transfers.Events;

public class TransferCreatedHandler : INotificationHandler<TransferCreated>
{
    private readonly IMovementRepository _movementRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAccountRepository _accountRepository;

    private readonly ITransferRepository _transferRepository;

    public TransferCreatedHandler(IMovementRepository movementRepository, ICategoryRepository categoryRepository, IAccountRepository accountRepository, ITransferRepository transferRepository)
    {
        _movementRepository = movementRepository;
        _categoryRepository = categoryRepository;
        _accountRepository = accountRepository;
        _transferRepository = transferRepository;
    }

    public Task Handle(TransferCreated notification, CancellationToken cancellationToken)
    {

        // verificar si tiene suficiente dinero en la cuenta de origen para hacer la transferencia
        if (_accountRepository.GetBalanceByAccountId(notification.Transfer.OriginAccountId.Value) < notification.Transfer.Amount.Value)
        {
            throw new Exception("No tiene suficiente dinero en la cuenta de origen para hacer la transferencia");
        }
        // insertar un movimiento de tipo egreso en la cuenta de origen
        var originMovement = Movement.Create(
            notification.Transfer.Description,
            Amount.Create(notification.Transfer.Amount.Value),
            "E",
            AccountId.Create(notification.Transfer.OriginAccountId.Value),
            CategoryId.Create(notification.CategoryId.Value),
            notification.Transfer.CreatedDate
        );

        // insertar un movimiento de tipo ingreso en la cuenta de destino
        var destinationMovement = Movement.Create(
            notification.Transfer.Description,
            Amount.Create(notification.Transfer.Amount.Value),
            "I",
            AccountId.Create(notification.Transfer.DestinationAccountId.Value),
            CategoryId.Create(notification.CategoryId.Value),
            notification.Transfer.CreatedDate
        );

        _movementRepository.Add(originMovement);
        _movementRepository.Add(destinationMovement);

        // actualizar ids de movimientos en la transferencia
        notification.Transfer.UpdateMovements(originMovement.Id, destinationMovement.Id);

        _transferRepository.Update(notification.Transfer);

        return Task.CompletedTask;

    }
}