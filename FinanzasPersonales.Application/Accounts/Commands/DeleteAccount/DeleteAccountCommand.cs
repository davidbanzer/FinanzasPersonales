using MediatR;

namespace FinanzasPersonales.Application.Accounts.Commands.DeleteAccount;

public record DeleteAccountCommand(
    Guid Id
) : IRequest<Unit>;
