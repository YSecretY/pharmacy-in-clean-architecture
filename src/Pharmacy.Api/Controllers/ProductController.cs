using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Products.Create;
using Pharmacy.Contracts.Products.Common;
using ErrorOr;
using Pharmacy.Application.Products.Get;
using Pharmacy.Contracts.Products.Create;
using Pharmacy.Contracts.Products.Get;
using Pharmacy.Domain.Product;

namespace Pharmacy.Api.Controllers;

[Route("products")]
[Authorize(Roles = "Admin")]
public class ProductController(
    IMapper mapper,
    ISender mediator) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        CreateProductCommand command = mapper.Map<CreateProductCommand>(request);
        ErrorOr<Created> productCreationResult = await mediator.Send(command);

        return productCreationResult.Match(
            _ => Ok(),
            Problem
        );
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetProduct([FromQuery] GetProductRequest request)
    {
        GetProductCommand command = mapper.Map<GetProductCommand>(request);
        ErrorOr<Product> getProductResult = await mediator.Send(command);

        return getProductResult.Match(
            product => Ok(mapper.Map<ProductResponse>(product)),
            Problem
        );
    }
}