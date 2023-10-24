using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Application.Transfers.Common;
using MediatR;

namespace FinanzasPersonales.Application.Transfers.Queries.GetTransferByUserId;

public class GetTransfersByUserIdQueryHandler : IRequestHandler<GetTransfersByUserIdQuery, List<TransferResult>>
{
    private readonly ITransferRepository _transferRepository;
    private readonly IUserRepository _userRepository;

    public GetTransfersByUserIdQueryHandler(ITransferRepository transferRepository, IUserRepository userRepository)
    {
        _transferRepository = transferRepository;
        _userRepository = userRepository;
    }

    public async Task<List<TransferResult>> Handle(GetTransfersByUserIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Obtener al usuario
        var user = _userRepository.GetUserById(request.UserId);

        if(user is null)
        {
            throw new Exception("El usuario no existe");
        }

        // Obtener las transferencias del usuario
        var transfers = _transferRepository.GetTransfersByUserId(request.UserId);

        // Retornar las transferencias

        if (transfers is null)
        {
            return new List<TransferResult>();
        }

        return transfers.Select(transfer => new TransferResult(transfer)).ToList();

    }
}