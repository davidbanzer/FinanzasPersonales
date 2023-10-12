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
            "Gastos Esenciales",
            "Incluye los gastos necesarios para tu vida diaria, como vivienda, alimentos y transporte.",
            notification.User.Id
          );

        var category2 = Category.Create(
          "Ahorro e Inversión",
          "Registra el dinero que estás reservando para tus metas de ahorro y las inversiones que estás haciendo para asegurar tu futuro financiero.",
          notification.User.Id
        );

        var category3 = Category.Create(
          "Deudas y Obligaciones",
          "Aquí puedes llevar un seguimiento de tus deudas y los pagos relacionados con préstamos o tarjetas de crédito.",
          notification.User.Id
        );

        var transferCategory = Category.Create(
          "Transferencias",
          "Aquí puedes llevar un seguimiento de tus transferencias entre cuentas.",
          notification.User.Id
        );

        _accountRepository.Add(account);
        _categoryRepository.Add(category1);
        _categoryRepository.Add(category2);
        _categoryRepository.Add(category3);
        _categoryRepository.Add(transferCategory);
        
        return Task.CompletedTask;
    }
}