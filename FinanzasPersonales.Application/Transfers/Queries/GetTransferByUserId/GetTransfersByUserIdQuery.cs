using FinanzasPersonales.Application.Transfers.Common;
using MediatR;

namespace FinanzasPersonales.Application.Transfers.Queries.GetTransferByUserId;

public record GetTransfersByUserIdQuery(Guid UserId) : IRequest<List<TransferResult>>;