using FinanzasPersonales.Application.Accounts.Common;
using FinanzasPersonales.Domain.AccountAggregate;
using MediatR;

namespace FinanzasPersonales.Application.Accounts.Queries.GetAccountsByUserId;

public record GetAccountsByUserIdQuery(
  Guid UserId
) : IRequest<List<AccountResult>>;