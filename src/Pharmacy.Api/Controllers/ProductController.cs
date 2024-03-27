using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Contracts.Products.Common;
using ErrorOr;
using Pharmacy.Application.Products.Commands.Create;
using Pharmacy.Application.Products.Commands.Remove;
using Pharmacy.Application.Products.Queries.GetById;
using Pharmacy.Contracts.Brands.Remove;
using Pharmacy.Contracts.Products.Create;
using Pharmacy.Contracts.Products.Get;
using Pharmacy.Contracts.Products.Remove;
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
    public async Task<IActionResult> GetProductById([FromQuery] GetProductRequest request)
    {
        GetProductByIdCommand command = mapper.Map<GetProductByIdCommand>(request);
        ErrorOr<Product> getProductResult = await mediator.Send(command);

        return getProductResult.Match(
            product => Ok(mapper.Map<ProductResponse>(product)),
            Problem
        );
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveProductById([FromQuery] RemoveProductByIdRequest request)
    {
        RemoveProductByIdCommand command = mapper.Map<RemoveProductByIdCommand>(request);
        ErrorOr<Deleted> deleteProductResult = await mediator.Send(command);

        return deleteProductResult.Match(
            _ => Ok(),
            Problem
        );
    }
}