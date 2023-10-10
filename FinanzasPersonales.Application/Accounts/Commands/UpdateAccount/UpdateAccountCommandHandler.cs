using FinanzasPersonales.Application.Accounts.Common;
using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.AccountAggregate;
using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace FinanzasPersonales.Application.Accounts.Commands.UpdateAccount;

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, AccountResult>
{
    private readonly IAccountRepository _accountRepository;

    public UpdateAccountCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountResult> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Obtener cuenta existente desde la base de datos
        var account = _accountRepository.GetById(request.Id);

        if (account is null)
        {
            throw new Exception("La cuenta no existe");
        }

        // Actualizar las propiedades de la entidad existente
        account.Update(
            request.Name,
            request.Description,
            Amount.Create(request.InitialBalance),
            UserId.Create(request.UserId)
        );

        // Guardar los cambios en el contexto
        _accountRepository.Update(account);

        // Retornar cuenta
        return new AccountResult(account);
    }
}