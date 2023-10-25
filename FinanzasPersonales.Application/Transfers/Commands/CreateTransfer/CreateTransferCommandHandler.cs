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
    private readonly IAccountRepository _accountRepository;


    public CreateTransferCommandHandler(ITransferRepository transferRepository, IAccountRepository accountRepository)
    {
        _transferRepository = transferRepository;
        _accountRepository = accountRepository;
    }

    public async Task<TransferResult> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if(request.OriginAccountId == request.DestinationAccountId)
        {
            throw new Exception("La cuenta de origen y la cuenta de destino no pueden ser la misma");
        }

        // Comprobar si la cuenta de origen tiene saldo suficiente
        var originAccount = _accountRepository.GetAccountById(request.OriginAccountId);

        if(originAccount is null)
        {
            throw new Exception("La cuenta de origen no existe");
        }

        if(_accountRepository.GetBalanceByAccountId(originAccount.Id.Value) < request.Amount)
        {
            throw new Exception("La cuenta de origen no tiene saldo suficiente");
        }


        var transfer = Transfer.Create(
            request.Description,
            Amount.Create(request.Amount),
            AccountId.Create(request.OriginAccountId),
            AccountId.Create(request.DestinationAccountId),
            MovementId.Create(new Guid()),
            MovementId.Create(new Guid()),
            CategoryId.Create(request.CategoryId),
            request.CreatedDate
        );

        _transferRepository.Add(transfer);

        return new TransferResult(transfer);
    }
}