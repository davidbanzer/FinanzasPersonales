using FinanzasPersonales.Application.Movements.Commands;
using FinanzasPersonales.Application.Movements.Commands.DeleteMovement;
using FinanzasPersonales.Application.Movements.Commands.UpdateMovement;
using FinanzasPersonales.Application.Movements.Common;
using FinanzasPersonales.Application.Movements.Queries;
using FinanzasPersonales.Application.Movements.Queries.GetMovementsByDate;
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

        // Update
        config.NewConfig<(UpdateMovementRequest Request, Guid Id), UpdateMovementCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest, src => src.Request);

        // Delete
        config.NewConfig<Guid, DeleteMovementCommand>()
            .Map(dest => dest.Id, src => src);

        // GetMovementByUserId
        config.NewConfig<Guid, GetMovementsByUserIdQuery>()
            .Map(dest => dest.UserId, src => src);

        // GetMovementsByDate
        config.NewConfig<(GetMovementsByDateRequest Request, Guid UserId), GetMovementsByDateQuery>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);
    }
}