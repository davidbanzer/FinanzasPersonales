using FinanzasPersonales.Application.Accounts.Common;
using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using MediatR;

namespace FinanzasPersonales.Application.Accounts.Queries.GetAccountsByUserId;

public class GetAccountsByUserIdQueryHandler : IRequestHandler<GetAccountsByUserIdQuery, List<AccountResult>>
{
    private readonly IAccountRepository _accountRepository;

    public GetAccountsByUserIdQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<List<AccountResult>> Handle(GetAccountsByUserIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Obtener cuentas
        var accounts = _accountRepository.GetAccountsByUserId(request.UserId);
        
        // Retornar cuentas
        if (accounts is null)
        {
            return new List<AccountResult>();
        }

        return accounts.Select(account => new AccountResult(account)).ToList();

    }
}