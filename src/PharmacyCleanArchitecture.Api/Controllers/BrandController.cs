using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyCleanArchitecture.Application.Brands.Commands.Create;
using PharmacyCleanArchitecture.Application.Brands.Commands.Remove;
using PharmacyCleanArchitecture.Application.Brands.Commands.Update;
using PharmacyCleanArchitecture.Application.Brands.Queries.GetBrandById;
using PharmacyCleanArchitecture.Application.Brands.Queries.GetBrandList;
using PharmacyCleanArchitecture.Contracts.Brands.Common;
using PharmacyCleanArchitecture.Contracts.Brands.Create;
using PharmacyCleanArchitecture.Contracts.Brands.Get;
using PharmacyCleanArchitecture.Contracts.Brands.Remove;
using PharmacyCleanArchitecture.Contracts.Brands.Update;
using PharmacyCleanArchitecture.Domain.Brands;
using PharmacyCleanArchitecture.Domain.Users.Enums;

namespace PharmacyCleanArchitecture.Api.Controllers;

[Route("brands/")]
[Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.SuperAdmin))]
public class BrandController(
    IMapper mapper,
    ISender mediator)
    : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateBrand([FromBody] CreateBrandRequest request)
    {
        CreateBrandCommand command = mapper.Map<CreateBrandCommand>(request);
        ErrorOr<Brand> createBrandResult = await mediator.Send(command);

        return createBrandResult.Match(
            brand => Ok(mapper.Map<BrandResponse>(brand)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> GetBrandById([FromQuery] GetBrandRequest request)
    {
        GetBrandByIdQuery query = mapper.Map<GetBrandByIdQuery>(request);
        ErrorOr<Brand> getBrandResult = await mediator.Send(query);

        return getBrandResult.Match(
            brand => Ok(mapper.Map<BrandResponse>(brand)),
            Problem);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetBrandList([FromQuery] GetBrandListRequest request)
    {
        GetBrandListQuery query = mapper.Map<GetBrandListQuery>(request);
        ErrorOr<GetBrandListQueryResponse> queryResponse = await mediator.Send(query);

        return queryResponse.Match(
            list => Ok(mapper.Map<GetBrandListResponse>(list)),
            Problem
        );
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandRequest request)
    {
        UpdateBrandCommand command = mapper.Map<UpdateBrandCommand>(request);
        ErrorOr<Updated> commandResponse = await mediator.Send(command);

        return commandResponse.Match(
            _ => Ok(),
            Problem
        );
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveBrand([FromQuery] RemoveBrandByIdRequest request)
    {
        RemoveBrandByIdCommand command = mapper.Map<RemoveBrandByIdCommand>(request);
        ErrorOr<Deleted> commandResponse = await mediator.Send(command);

        return commandResponse.Match(
            _ => Ok(),
            Problem
        );
    }
}