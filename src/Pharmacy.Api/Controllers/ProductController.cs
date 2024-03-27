using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Products.Create;
using Pharmacy.Contracts.Products;
using Pharmacy.Contracts.Products.Common;
using ErrorOr;
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
        ErrorOr<Product> productCreationResult = await mediator.Send(command);

        return productCreationResult.Match(
            product => Ok(mapper.Map<ProductResponse>(product)),
            Problem
        );
    }
}