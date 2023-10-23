using FinanzasPersonales.Application.Accounts.Common;
using MediatR;

namespace FinanzasPersonales.Application.Accounts.Queries.GetAccountById;

public record GetAccountByIdQuery(Guid Id) : IRequest<AccountResult>;