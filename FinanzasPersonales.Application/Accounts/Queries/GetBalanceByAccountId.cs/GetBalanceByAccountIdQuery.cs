using MediatR;

namespace FinanzasPersonales.Application.Accounts.Queries.GetBalanceByAccountId.cs;

public record GetBalanceByAccountIdQuery(Guid AccountId) : IRequest<decimal>;