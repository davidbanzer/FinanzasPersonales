using FinanzasPersonales.Domain.Account;
using MediatR;

namespace FinanzasPersonales.Application.Accounts.Commands.CreateAccount;

public record CreateAccountCommand(
    string Name,
    string Description,
    decimal InitialBalance,
    Guid UserId
) : IRequest<Account>;