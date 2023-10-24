using FinanzasPersonales.Application.Transfers.Common;
using MediatR;

namespace FinanzasPersonales.Application.Transfers.Commands.CreateTransfer;

public record CreateTransferCommand(
    string Description,
    decimal Amount,
    Guid OriginAccountId,
    Guid DestinationAccountId,
    Guid CategoryId,
    DateTime CreatedDate
) : IRequest<TransferResult>;
