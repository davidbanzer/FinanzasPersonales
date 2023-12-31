using FinanzasPersonales.Application.Categories.Commands.CreateCategory;
using FinanzasPersonales.Application.Categories.Commands.DeleteCategory;
using FinanzasPersonales.Application.Categories.Commands.UpdateCategory;
using FinanzasPersonales.Application.Categories.Queries.GetCategoriesByUserId;
using FinanzasPersonales.Application.Categories.Queries.GetCategoryById;
using FinanzasPersonales.Contracts.Categories;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.Api.Controllers;

[ApiController]
[Route("categories")]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public CategoriesController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
    {
        var command = _mapper.Map<CreateCategoryCommand>(request);

        var createCategoryResult = await _mediator.Send(command);

        var response = _mapper.Map<CategoryResponse>(createCategoryResult);

        return Ok(response);
    }

    [HttpPut("{categoryId}")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest request, Guid categoryId)
    {
        var command = _mapper.Map<UpdateCategoryCommand>((request, categoryId));

        var updateCategoryResult = await _mediator.Send(command);

        var response = _mapper.Map<CategoryResponse>(updateCategoryResult);

        return Ok(response);
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteCategory(Guid categoryId)
    {
        var command = _mapper.Map<DeleteCategoryCommand>(categoryId);

        var deleteCategoryResult = await _mediator.Send(command);

        return Ok(deleteCategoryResult);
    }

    [HttpGet("all/{userId}")]
    public async Task<IActionResult> GetCategoriesByUserId(Guid userId)
    {
        var query = _mapper.Map<GetCategoriesByUserIdQuery>(userId);

        var categories = await _mediator.Send(query);

        var response = _mapper.Map<IEnumerable<CategoryResponse>>(categories);

        return Ok(response);
    }

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetCategoryById(Guid categoryId)
    {
        var query = _mapper.Map<GetCategoryByIdQuery>(categoryId);

        var category = await _mediator.Send(query);

        var response = _mapper.Map<CategoryResponse>(category);

        return Ok(response);
    }
}