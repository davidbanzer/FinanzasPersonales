using FinanzasPersonales.Application.Categories.Commands.CreateCategory;
using FinanzasPersonales.Application.Categories.Commands.UpdateCategory;
using FinanzasPersonales.Application.Categories.Common;
using FinanzasPersonales.Contracts.Categories;
using Mapster;

namespace FinanzasPersonales.Api.Common.Mapping;

public class CategoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Create
        config.NewConfig<(CreateCategoryRequest Request, Guid UserId), CreateCategoryCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<CategoryResult, CategoryResponse>()
            .Map(dest => dest.Id, src => src.Category.Id.Value)
            .Map(dest => dest.Name, src => src.Category.Name)
            .Map(dest => dest.Description, src => src.Category.Description)
            .Map(dest => dest.UserId, src => src.Category.UserId.Value);

        // Update
        config.NewConfig<(UpdateCategoryRequest Request, Guid CategoryId), UpdateCategoryCommand>()
            .Map(dest => dest.Id, src => src.CategoryId)
            .Map(dest => dest, src => src.Request);


    }
}
