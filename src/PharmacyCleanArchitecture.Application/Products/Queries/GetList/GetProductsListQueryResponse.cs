using PharmacyCleanArchitecture.Domain.Products;

namespace PharmacyCleanArchitecture.Application.Products.Queries.GetList;

public record GetProductsListQueryResponse(List<Product> Products, int PageSize, int PageNumber, int MaxPages);