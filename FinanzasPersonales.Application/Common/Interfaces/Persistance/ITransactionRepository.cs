
using FinanzasPersonales.Domain.TransferAggregate;

namespace FinanzasPersonales.Application.Common.Interfaces.Persistance;

public interface ITransferRepository
{
    void Add(Transfer Transfer);

    Transfer? GetTransferById(Guid id);

    List<Transfer>? GetTransfersByUserId(Guid userId);

    List<Transfer>? GetTransfersByMovementId(Guid movementId);

    void Update(Transfer Transfer);

    void Delete(Transfer Transfer);
}