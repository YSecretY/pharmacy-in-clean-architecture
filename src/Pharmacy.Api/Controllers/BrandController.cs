using MapsterMapper;
using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Brands;
using Pharmacy.Application.Brands.Commands.CreateBrand;
using Pharmacy.Application.Brands.Queries.GetBrandById;
using Pharmacy.Contracts.Brands;
using Pharmacy.Contracts.Brands.Common;
using Pharmacy.Contracts.Brands.Create;
using Pharmacy.Contracts.Brands.Get;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Api.Controllers;

[Route("brands/")]
public class BrandController(
        IMapper mapper,
        ISender mediator)
    : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateBrand([FromBody] CreateBrandRequest createBrandRequest)
    {
        CreateBrandCommand createBrandCommand = mapper.Map<CreateBrandCommand>(createBrandRequest);
        ErrorOr<Brand> createBrandResult = await mediator.Send(createBrandCommand);

        return createBrandResult.Match(
            brand => Ok(mapper.Map<BrandResponse>(brand)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> GetBrandById([FromQuery] GetBrandRequest getBrandRequest)
    {
        GetBrandByIdQuery getBrandByIdQuery = mapper.Map<GetBrandByIdQuery>(getBrandRequest);
        ErrorOr<Brand> getBrandResult = await mediator.Send(getBrandByIdQuery);

        return getBrandResult.Match(
            brand => Ok(mapper.Map<BrandResponse>(brand)),
            Problem);
    }
}