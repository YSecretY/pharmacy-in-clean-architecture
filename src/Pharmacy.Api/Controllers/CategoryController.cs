using MapsterMapper;
using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Categories.Commands.Create;
using Pharmacy.Application.Categories.Commands.Queries;
using Pharmacy.Contracts.Category.Common;
using Pharmacy.Contracts.Category.Create;
using Pharmacy.Contracts.Category.Get;
using Pharmacy.Domain.Category;

namespace Pharmacy.Api.Controllers;

[Route("categories/")]
public class CategoryController(
        ISender mediator,
        IMapper mapper)
    : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
    {
        CreateCategoryCommand command = mapper.Map<CreateCategoryCommand>(request);
        ErrorOr<Category> commandResult = await mediator.Send(command);

        return commandResult.Match(
            category => Ok(mapper.Map<CategoryResponse>(category)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> GetCategory([FromQuery] GetCategoryByIdRequest request)
    {
        GetCategoryByIdQuery query = mapper.Map<GetCategoryByIdQuery>(request);
        ErrorOr<Category> queryResult = await mediator.Send(query);

        return queryResult.Match(
            category => Ok(mapper.Map<CategoryResponse>(category)),
            Problem);
    }
}