using FinanzasPersonales.Domain.AccountAggregate;
using MediatR;

namespace FinanzasPersonales.Application.Accounts.Commands.CreateAccount;

public record CreateAccountCommand(
    string Name,
    string Description,
    decimal InitialBalance,
    Guid UserId
) : IRequest<Account>;