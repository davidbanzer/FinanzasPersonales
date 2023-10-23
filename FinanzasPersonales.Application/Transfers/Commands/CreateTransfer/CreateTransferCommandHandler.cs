using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Application.Transfers.Common;
using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.MovementAggregate.ValueObjects;
using FinanzasPersonales.Domain.TransferAggregate;
using MediatR;

namespace FinanzasPersonales.Application.Transfers.Commands.CreateTransfer;

public class CreateTransferCommandHandler : IRequestHandler<CreateTransferCommand, TransferResult>
{
    private readonly ITransferRepository _transferRepository;


    public CreateTransferCommandHandler(
        ITransferRepository transferRepository)
    {
        _transferRepository = transferRepository;
    }

    public async Task<TransferResult> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var transfer = Transfer.Create(
            request.Description,
            Amount.Create(request.Amount),
            AccountId.Create(request.OriginAccountId),
            AccountId.Create(request.DestinationAccountId),
            MovementId.Create(new Guid()),
            MovementId.Create(new Guid()),
            CategoryId.Create(request.CategoryId)
        );

        _transferRepository.Add(transfer);

        return new TransferResult(transfer);
    }
}