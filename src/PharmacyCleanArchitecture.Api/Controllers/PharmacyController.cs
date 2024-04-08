using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyCleanArchitecture.Application.Pharmacies.Commands.AddProducts.Existing;
using PharmacyCleanArchitecture.Application.Pharmacies.Commands.AddProducts.New;
using PharmacyCleanArchitecture.Application.Pharmacies.Commands.Create;
using PharmacyCleanArchitecture.Application.Pharmacies.Queries.GetProductById;
using PharmacyCleanArchitecture.Application.Pharmacies.Queries.GetProductsList;
using PharmacyCleanArchitecture.Contracts.Pharmacies.AddProducts;
using PharmacyCleanArchitecture.Contracts.Pharmacies.Common;
using PharmacyCleanArchitecture.Contracts.Pharmacies.Create;
using PharmacyCleanArchitecture.Contracts.Pharmacies.GetProducts;
using PharmacyCleanArchitecture.Domain.PharmacyAggregate;
using PharmacyCleanArchitecture.Domain.Users.Enums;

namespace PharmacyCleanArchitecture.Api.Controllers;

[Route("pharmacies")]
[Authorize(Roles = nameof(UserRole.SuperAdmin))]
public class PharmacyController(
    ISender mediator,
    IMapper mapper
) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreatePharmacy(CreatePharmacyRequest request)
    {
        CreatePharmacyCommand command = mapper.Map<CreatePharmacyCommand>(request);
        ErrorOr<Pharmacy> pharmacyCreationResult = await mediator.Send(command);

        return pharmacyCreationResult.Match(
            pharmacy => Ok(mapper.Map<PharmacyResponse>(pharmacy)),
            Problem
        );
    }

    [HttpPost("add-new-product")]
    [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.SuperAdmin))]
    public async Task<IActionResult> AddNewProductToPharmacy(AddNewProductToPharmacyRequest request)
    {
        AddNewProductToPharmacyCommand command = mapper.Map<AddNewProductToPharmacyCommand>(request);
        ErrorOr<Success> productAddResult = await mediator.Send(command);

        return productAddResult.Match(
            _ => Ok(),
            Problem
        );
    }

    [HttpPut("add-existing-product")]
    [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.SuperAdmin))]
    public async Task<IActionResult> AddExistingProductToPharmacy(AddExistingProductToPharmacyRequest request)
    {
        AddExistingProductToPharmacyCommand command = mapper.Map<AddExistingProductToPharmacyCommand>(request);
        ErrorOr<Success> productAddResult = await mediator.Send(command);

        return productAddResult.Match(
            _ => Ok(),
            Problem
        );
    }

    [HttpGet("product")]
    [AllowAnonymous]
    public async Task<IActionResult> GetPharmacyProductById([FromQuery] GetPharmacyProductByIdRequest request)
    {
        GetPharmacyProductByIdQuery query = mapper.Map<GetPharmacyProductByIdQuery>(request);
        ErrorOr<GetPharmacyProductByIdQueryResponse> getProductResult = await mediator.Send(query);

        return getProductResult.Match(
            product => Ok(mapper.Map<GetPharmacyProductByIdResponse>(product)),
            Problem
        );
    }

    [HttpGet("products")]
    [AllowAnonymous]
    public async Task<IActionResult> GetPharmacyProductsList([FromQuery] GetPharmacyProductsListRequest request)
    {
        GetPharmacyProductsListQuery query = mapper.Map<GetPharmacyProductsListQuery>(request);
        ErrorOr<GetPharmacyProductsListQueryResponse> getProductsResult = await mediator.Send(query);

        return getProductsResult.Match(
            products => Ok(mapper.Map<GetPharmacyProductsListResponse>(products)),
            Problem
        );
    }
}