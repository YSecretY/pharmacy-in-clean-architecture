using Pharmacy.Contracts.Products.Common;
using Pharmacy.Domain.Product;

namespace Pharmacy.Application.Products.Queries.GetList;

public record GetProductsListQueryResponse(List<Product> Products, int PageSize, int PageNumber, int MaxPages);