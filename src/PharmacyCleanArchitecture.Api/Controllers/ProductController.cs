using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyCleanArchitecture.Application.Products.Commands.Create;
using PharmacyCleanArchitecture.Application.Products.Commands.Remove;
using PharmacyCleanArchitecture.Application.Products.Queries.GetById;
using PharmacyCleanArchitecture.Application.Products.Queries.GetList;
using PharmacyCleanArchitecture.Contracts.Products.Common;
using PharmacyCleanArchitecture.Contracts.Products.Create;
using PharmacyCleanArchitecture.Contracts.Products.Get;
using PharmacyCleanArchitecture.Contracts.Products.Remove;
using PharmacyCleanArchitecture.Domain.Products;
using PharmacyCleanArchitecture.Domain.Users.Enums;

namespace PharmacyCleanArchitecture.Api.Controllers;

[Route("products")]
[Authorize(Roles = nameof(UserRole.Admin))]
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
        GetProductByIdQuery query = mapper.Map<GetProductByIdQuery>(request);
        ErrorOr<Product> getProductResult = await mediator.Send(query);

        return getProductResult.Match(
            product => Ok(mapper.Map<ProductResponse>(product)),
            Problem
        );
    }

    [HttpGet("list")]
    [AllowAnonymous]
    public async Task<IActionResult> GetProductList([FromQuery] GetProductsListRequest request)
    {
        GetProductsListQuery query = mapper.Map<GetProductsListQuery>(request);
        ErrorOr<GetProductsListQueryResponse> getProductListResult = await mediator.Send(query);

        return getProductListResult.Match(
            list => Ok(mapper.Map<GetProductListResponse>(list)),
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