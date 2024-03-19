using MapsterMapper;
using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Brands;
using Pharmacy.Contracts.Brands;
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
            brand => Ok(mapper.Map<BrandResponse>(brand)), Problem);
    }
}