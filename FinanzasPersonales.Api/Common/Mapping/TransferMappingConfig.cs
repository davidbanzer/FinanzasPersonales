using FinanzasPersonales.Application.Transfers.Commands.CreateTransfer;
using FinanzasPersonales.Application.Transfers.Commands.DeleteTransfer;
using FinanzasPersonales.Application.Transfers.Common;
using FinanzasPersonales.Application.Transfers.Queries.GetTransferByUserId;
using FinanzasPersonales.Contracts.Transfers;
using Mapster;

namespace FinanzasPersonales.Api.Common.Mapping;

public class TransferMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Create
        config.NewConfig<CreateTransferRequest, CreateTransferCommand>()
            .Map(dest => dest, src => src);

        // GetByUserId
        config.NewConfig<Guid, GetTransfersByUserIdQuery>()
            .Map(dest => dest.UserId, src => src);

        // Delete
        config.NewConfig<Guid, DeleteTransferCommand>()
            .Map(dest => dest.TransferId, src => src);

        config.NewConfig<TransferResult, TransferResponse>()
            .Map(dest => dest.Id, src => src.Transfer.Id.Value)
            .Map(dest => dest.Description, src => src.Transfer.Description)
            .Map(dest => dest.Amount, src => src.Transfer.Amount.Value)
            .Map(dest => dest.OriginAccountId, src => src.Transfer.OriginAccountId.Value)
            .Map(dest => dest.DestinationAccountId, src => src.Transfer.DestinationAccountId.Value)
            .Map(dest => dest.OriginMovementId, src => src.Transfer.OriginMovementId.Value)
            .Map(dest => dest.DestinationMovementId, src => src.Transfer.DestinationMovementId.Value)
            .Map(dest => dest.CreatedDate, src => src.Transfer.CreatedDate);
    }
}