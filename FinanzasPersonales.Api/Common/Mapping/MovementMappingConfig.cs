using FinanzasPersonales.Application.Movements.Commands;
using FinanzasPersonales.Application.Movements.Common;
using FinanzasPersonales.Contracts.Movements;
using Mapster;

namespace FinanzasPersonales.Api.Common.Mapping;

public class MovementMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Create
        config.NewConfig<CreateMovementRequest, CreateMovementCommand>()
            .Map(dest => dest, src => src);
        
        config.NewConfig<MovementResult, MovementResponse>()
            .Map(dest => dest.Id, src => src.Movement.Id.Value)
            .Map(dest => dest.Description, src => src.Movement.Description)
            .Map(dest => dest.Amount, src => src.Movement.Amount.Value)
            .Map(dest => dest.Type, src => src.Movement.Type)
            .Map(dest => dest.AccountId, src => src.Movement.AccountId.Value)
            .Map(dest => dest.CategoryId, src => src.Movement.CategoryId.Value)
            .Map(dest => dest.CreatedDate, src => src.Movement.CreatedDate);
    }
}