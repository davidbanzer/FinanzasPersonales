using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using MediatR;

namespace FinanzasPersonales.Application.Accounts.Commands.DeleteAccount;

public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit>
{
    private readonly IAccountRepository _accountRepository;

    public DeleteAccountCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Obtener la cuenta
        var account = _accountRepository.GetAccountById(request.Id);

        if (account is null)
        {
            throw new Exception("La cuenta no existe");
        }

        // Eliminar la cuenta
        _accountRepository.Delete(account);

        // Retornar
        return Unit.Value;

    }
}