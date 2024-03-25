using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Category;
using Z.EntityFramework.Plus;

namespace Pharmacy.Application.Categories.Commands.Remove;

public class RemoveCategoryByIdCommandHandler(
    IPharmacyDbContext dbContext
) : IRequestHandler<RemoveCategoryByIdCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(RemoveCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        int deletedCount = await dbContext.Categories
            .Where(b => b.Id == request.Guid)
            .DeleteAsync(cancellationToken);
        
        if (deletedCount is 0) return Error.NotFound(description: "Category is not found.");

        return Result.Deleted;
    }
}