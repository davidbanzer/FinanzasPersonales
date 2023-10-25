using FinanzasPersonales.Application.Transfers.Common;
using MediatR;

namespace FinanzasPersonales.Application.Transfers.Commands.UpdateTransfer;

public record UpdateTransferCommand(
    Guid Id,
    string Description,
    decimal Amount,
    Guid OriginAccountId,
    Guid DestinationAccountId,
    Guid CategoryId,
    DateTime CreatedDate
) : IRequest<TransferResult>;