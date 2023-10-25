using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using MediatR;

namespace FinanzasPersonales.Application.Transfers.Commands.DeleteTransfer;

public class DeleteTransferCommandHandler: IRequestHandler<DeleteTransferCommand, Unit>
{
    private readonly ITransferRepository _transferRepository;

    public DeleteTransferCommandHandler(ITransferRepository transferRepository)
    {
        _transferRepository = transferRepository;
    }

    public async Task<Unit> Handle(DeleteTransferCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Obtener la transferencia
        var transfer = _transferRepository.GetTransferById(request.TransferId);

        if(transfer is null)
        {
            throw new Exception("La transferencia no existe");
        }

        // Eliminar la transferencia
        transfer.Delete();
        _transferRepository.Delete(transfer);

        return Unit.Value;
        
    }
}