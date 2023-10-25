using MediatR;

namespace FinanzasPersonales.Application.Transfers.Commands.DeleteTransfer;

public record DeleteTransferCommand(Guid TransferId) : IRequest<Unit>;