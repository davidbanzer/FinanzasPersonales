using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Application.Transfers.Common;
using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.ValueObjects;
using MediatR;

namespace FinanzasPersonales.Application.Transfers.Commands.UpdateTransfer;

public class UpdateTransferCommandHandler : IRequestHandler<UpdateTransferCommand, TransferResult>
{
    private readonly ITransferRepository _transferRepository;
    private readonly IAccountRepository _accountRepository;

    public UpdateTransferCommandHandler(ITransferRepository transferRepository, IAccountRepository accountRepository)
    {
        _transferRepository = transferRepository;
        _accountRepository = accountRepository;
    }
    public async Task<TransferResult> Handle(UpdateTransferCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var transfer = _transferRepository.GetTransferById(request.Id);

        if(transfer is null)
        {
            throw new Exception("La transferencia no existe");
        }

        if(transfer.OriginAccountId == transfer.DestinationAccountId)
        {
            throw new Exception("La cuenta de origen y la cuenta de destino no pueden ser la misma");
        }

        var currentAmount = transfer.Amount.Value;
        
        var currentAccountAmount = _accountRepository.GetBalanceByAccountId(transfer.OriginAccountId.Value);

        var newAccountAmount = currentAccountAmount - currentAmount;

        if(newAccountAmount < request.Amount)
        {
            throw new Exception("La cuenta de origen no tiene saldo suficiente");
        }

        transfer.Update(
            request.Description,
            Amount.Create(request.Amount),
            AccountId.Create(request.OriginAccountId),
            AccountId.Create(request.DestinationAccountId),
            CategoryId.Create(request.CategoryId),
            request.CreatedDate
        );

        _transferRepository.Update(transfer);

        return new TransferResult(transfer);
    }
}