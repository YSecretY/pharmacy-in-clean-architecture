using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Common.Interfaces.Persistence;
using Pharmacy.Domain.Category;

namespace Pharmacy.Application.Categories.Commands.Queries.GetCategoryById;

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