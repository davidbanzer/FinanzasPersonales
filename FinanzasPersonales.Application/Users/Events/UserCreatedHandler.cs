using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.AccountAggregate;
using FinanzasPersonales.Domain.CategoryAggregate;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.UserAggregate.Events;
using MediatR;

namespace FinanzasPersonales.Application.Authentication.Events;

public class UserCreatedHandler : INotificationHandler<UserCreated>
{
  private readonly IAccountRepository _accountRepository;
  private readonly ICategoryRepository _categoryRepository;

  public UserCreatedHandler(IAccountRepository accountRepository, ICategoryRepository categoryRepository)
  {
    _accountRepository = accountRepository;
    _categoryRepository = categoryRepository;
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

    var category1 = Category.Create(
        "Alimentación",
        "Registra los gastos relacionados con la alimentación, como la compra de alimentos, comidas en restaurantes, etc.",
        notification.User.Id
      );

    var category2 = Category.Create(
      "Transporte",
      "Aquí puedes llevar un seguimiento de los gastos relacionados con el transporte, como la compra de combustible, pasajes de autobús, etc.",
      notification.User.Id
    );

    var category3 = Category.Create(
      "Entretenimineto",
      "Aquí puedes llevar un seguimiento de los gastos relacionados con el entretenimiento, como la compra de entradas al cine, al teatro, etc.",
      notification.User.Id
    );

    _accountRepository.Add(account);
    _categoryRepository.Add(category1);
    _categoryRepository.Add(category2);
    _categoryRepository.Add(category3);

    return Task.CompletedTask;
  }
}