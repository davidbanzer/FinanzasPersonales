using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.Account;
using MediatR;

namespace FinanzasPersonales.Application.Accounts.Queries.GetAccountsByUserId;

public class GetAccountsByUserIdQueryHandler : IRequestHandler<GetAccountsByUserIdQuery, List<Account>>
{
    private readonly IAccountRepository _accountRepository;

    public GetAccountsByUserIdQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<List<Account>> Handle(GetAccountsByUserIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Obtener cuentas
        var accounts = _accountRepository.GetAccountsByUserId(request.UserId);
        
        if (accounts is null)
        {
            accounts = new List<Account>();
        }
        
        // Retornar cuentas
        return accounts;
    }
}