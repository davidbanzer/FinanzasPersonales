using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using MediatR;

namespace FinanzasPersonales.Application.Accounts.Queries.GetBalanceByAccountId.cs;

public class GetBalanceByAccountIdQueryHandler : IRequestHandler<GetBalanceByAccountIdQuery, decimal>
{
    private readonly IAccountRepository _accountRepository;

    public GetBalanceByAccountIdQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<decimal> Handle(GetBalanceByAccountIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        if(_accountRepository.GetAccountById(request.AccountId) is null)
        {
            throw new Exception("La cuenta no existe");
        }
            
        var balance = _accountRepository.GetBalanceByAccountId(request.AccountId);

        return balance;
    }
}