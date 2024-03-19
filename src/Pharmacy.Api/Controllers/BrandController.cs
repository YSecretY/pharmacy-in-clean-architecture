using MapsterMapper;
using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Brands;
using Pharmacy.Contracts.Brands;
using Pharmacy.Domain.Brand;

namespace Pharmacy.Api.Controllers;

[Route("brands/")]
public class BrandController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public BrandController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand([FromBody] CreateBrandRequest createBrandRequest)
    {
        CreateBrandCommand createBrandCommand = _mapper.Map<CreateBrandCommand>(createBrandRequest);
        ErrorOr<Brand> createBrandResult = await _mediator.Send(createBrandCommand);

        return createBrandResult.Match(
            brand => Ok(_mapper.Map<BrandResponse>(brand)), Problem);
    }
}