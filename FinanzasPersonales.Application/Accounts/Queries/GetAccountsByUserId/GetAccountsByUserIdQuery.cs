using FinanzasPersonales.Domain.Account;
using MediatR;

namespace FinanzasPersonales.Application.Accounts.Queries.GetAccountsByUserId;

public record GetAccountsByUserIdQuery(
  Guid UserId
) : IRequest<List<Account>>;