using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.AccountAggregate;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.UserAggregate.Events;
using MediatR;

namespace FinanzasPersonales.Application.Authentication.Events;

public class UserCreatedHandler : INotificationHandler<UserCreated>
{
    private readonly IAccountRepository _accountRepository;

    public UserCreatedHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public Task Handle(UserCreated notification, CancellationToken cancellationToken)
    {
        // crear un account por defecto a este usuario
        var account = Account.Create(
           "Cuenta Principal",
           "Cuenta principal por defecto",
           Amount.Create(0),
           notification.User.Id
       );

        _accountRepository.Add(account);
        return Task.CompletedTask;
    }
}