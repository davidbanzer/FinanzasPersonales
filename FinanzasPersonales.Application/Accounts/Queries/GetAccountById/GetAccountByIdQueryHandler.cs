using FinanzasPersonales.Application.Accounts.Common;
using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using MediatR;

namespace FinanzasPersonales.Application.Accounts.Queries.GetAccountById;

public class GetAccountByIdQueryHandler: IRequestHandler<GetAccountByIdQuery, AccountResult>
{
    private readonly IAccountRepository _accountRepository;

    public GetAccountByIdQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountResult> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var account = _accountRepository.GetAccountById(request.Id);

        if(account is null)
        {
            throw new Exception("La cuenta no existe");
        }
        return new AccountResult(account);
    }
}