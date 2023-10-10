using FinanzasPersonales.Application.Accounts.Common;
using MediatR;

namespace FinanzasPersonales.Application.Accounts.Commands.UpdateAccount;
public record UpdateAccountCommand(
    Guid Id,
    string Name,
    string Description,
    decimal InitialBalance,
    Guid UserId
) : IRequest<AccountResult>;