using FinanzasPersonales.Application.Categories.Commands.CreateCategory;
using FinanzasPersonales.Application.Categories.Commands.DeleteCategory;
using FinanzasPersonales.Application.Categories.Commands.UpdateCategory;
using FinanzasPersonales.Application.Categories.Common;
using FinanzasPersonales.Application.Categories.Queries.GetCategoriesByUserId;
using FinanzasPersonales.Application.Categories.Queries.GetCategoryById;
using FinanzasPersonales.Contracts.Categories;
using FinanzasPersonales.Domain.UserAggregate.ValueObjects;
using Mapster;

namespace FinanzasPersonales.Api.Common.Mapping;

public class CategoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Create
        config.NewConfig<CreateCategoryRequest, CreateCategoryCommand>()
            .Map(dest => dest, src => src);

        config.NewConfig<CategoryResult, CategoryResponse>()
            .Map(dest => dest.Id, src => src.Category.Id.Value)
            .Map(dest => dest.Name, src => src.Category.Name)
            .Map(dest => dest.Description, src => src.Category.Description)
            .Map(dest => dest.UserId, src => src.Category.UserId.Value);

        // Update
        config.NewConfig<(UpdateCategoryRequest Request, Guid CategoryId), UpdateCategoryCommand>()
            .Map(dest => dest.Id, src => src.CategoryId)
            .Map(dest => dest, src => src.Request);

        // Delete
        config.NewConfig<Guid, DeleteCategoryCommand>()
            .Map(dest => dest.Id, src => src);

        // GetCategoriesByUserId
        config.NewConfig<Guid, GetCategoriesByUserIdQuery>()
            .Map(dest => dest.UserId, src => src);

        // GetCategoryById
        config.NewConfig<Guid, GetCategoryByIdQuery>()
            .Map(dest => dest.Id, src => src);

    }
}
