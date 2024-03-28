using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyCleanArchitecture.Application.Pharmacies.Commands.Create;
using PharmacyCleanArchitecture.Contracts.Pharmacies.Common;
using PharmacyCleanArchitecture.Contracts.Pharmacies.Create;
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
        ErrorOr<Domain.PharmacyAggregate.Pharmacy> pharmacyCreationResult = await mediator.Send(command);

        return pharmacyCreationResult.Match(
            pharmacy => Ok(mapper.Map<PharmacyResponse>(pharmacy)),
            Problem
        );
    }
}