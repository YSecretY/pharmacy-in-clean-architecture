using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyCleanArchitecture.Application.Common.Interfaces.Persistence;
using PharmacyCleanArchitecture.Domain.Categories;

namespace PharmacyCleanArchitecture.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler(
        IPharmacyDbContext dbContext)
    : IRequestHandler<GetCategoryByIdQuery, ErrorOr<Category>>
{
    public async Task<ErrorOr<Category>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        Category? category = await dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == request.Guid, cancellationToken);
        if (category is null) return Error.NotFound(description: "Category is not found.");

        return category;
    }
}