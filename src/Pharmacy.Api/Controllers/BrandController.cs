using MapsterMapper;
using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Brands.Commands.CreateBrand;
using Pharmacy.Application.Brands.Commands.RemoveBrand;
using Pharmacy.Application.Brands.Commands.UpdateBrand;
using Pharmacy.Application.Brands.Queries.GetBrandById;
using Pharmacy.Application.Brands.Queries.GetBrandList;
using Pharmacy.Contracts.Brands.Common;
using Pharmacy.Contracts.Brands.Create;
using Pharmacy.Contracts.Brands.Get;
using Pharmacy.Contracts.Brands.Remove;
using Pharmacy.Contracts.Brands.Update;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Api.Controllers;

[Route("brands/")]
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
        ErrorOr<Brand> commandResponse = await mediator.Send(command);

        return commandResponse.Match(
            brand => Ok(mapper.Map<BrandResponse>(brand)),
            Problem
        );
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveBrand([FromQuery] RemoveBrandByIdRequest request)
    {
        RemoveBrandByIdCommand command = mapper.Map<RemoveBrandByIdCommand>(request);
        ErrorOr<Success> commandResponse = await mediator.Send(command);

        return commandResponse.Match(
            _ => Ok(),
            Problem
        );
    }
}