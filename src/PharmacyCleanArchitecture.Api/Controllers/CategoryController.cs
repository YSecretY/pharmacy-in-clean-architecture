using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyCleanArchitecture.Application.Categories.Commands.Create;
using PharmacyCleanArchitecture.Application.Categories.Commands.Remove;
using PharmacyCleanArchitecture.Application.Categories.Commands.Update;
using PharmacyCleanArchitecture.Application.Categories.Queries.GetCategoryById;
using PharmacyCleanArchitecture.Application.Categories.Queries.GetCategoryList;
using PharmacyCleanArchitecture.Contracts.Categories.Common;
using PharmacyCleanArchitecture.Contracts.Categories.Create;
using PharmacyCleanArchitecture.Contracts.Categories.Get;
using PharmacyCleanArchitecture.Contracts.Categories.Remove;
using PharmacyCleanArchitecture.Contracts.Categories.Update;
using PharmacyCleanArchitecture.Domain.Categories;
using PharmacyCleanArchitecture.Domain.Users.Enums;

namespace PharmacyCleanArchitecture.Api.Controllers;

[Route("categories/")]
[Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.SuperAdmin))]
public class CategoryController(
    ISender mediator,
    IMapper mapper
) : ApiController
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

    [HttpGet("list")]
    public async Task<IActionResult> GetCategoryList([FromQuery] GetCategoryListRequest request)
    {
        GetCategoryListQuery query = mapper.Map<GetCategoryListQuery>(request);
        ErrorOr<GetCategoryListQueryResponse> queryResult = await mediator.Send(query);

        return queryResult.Match(
            response => Ok(mapper.Map<GetCategoryListResponse>(response)),
            Problem);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
    {
        UpdateCategoryCommand command = mapper.Map<UpdateCategoryCommand>(request);
        ErrorOr<Category> commandResult = await mediator.Send(command);

        return commandResult.Match(
            category => Ok(mapper.Map<CategoryResponse>(category)),
            Problem);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveCategory([FromQuery] RemoveCategoryByIdRequest request)
    {
        RemoveCategoryByIdCommand command = mapper.Map<RemoveCategoryByIdCommand>(request);
        ErrorOr<Deleted> commandResult = await mediator.Send(command);

        return commandResult.Match(
            _ => Ok(),
            Problem);
    }
}