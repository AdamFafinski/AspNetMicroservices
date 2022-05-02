using Catalog.API.App.Application.Dto;
using Catalog.API.App.Application.Responses;

namespace Catalog.API.App.Application.Interfaces;

public interface IProductService
{
    Task<AppResponse> CreateProduct(ProductDto product);
    Task<AppResponse> DeleteProduct(string id);
    Task<AppResponse<ProductDto>> GetProductById(string id);
    Task<AppResponse<IEnumerable<ProductDto>>> GetProducts();
    Task<AppResponse<IEnumerable<ProductDto>>> GetProductsByCategory(string categoryName);
    Task<AppResponse<IEnumerable<ProductDto>>> GetProductsByName(string name);
    Task<AppResponse> UpdateProduct(ProductDto product);
}
