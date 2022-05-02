using AutoMapper;
using Catalog.API.App.Application.Dto;
using Catalog.API.App.Application.Exceptions;
using Catalog.API.App.Application.Interfaces;
using Catalog.API.App.Application.Responses;
using Catalog.API.App.Domain.Entities;
using System.Net;

namespace Catalog.API.App.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<AppResponse> CreateProduct(ProductDto product)
        {
            var newProduct = _mapper.Map<Product>(product);
            await _productRepository.CreateProduct(newProduct);
            return new AppResponse(true, "Operation Success.");
        }

        public async Task<AppResponse> DeleteProduct(string id)
        {
            var isDeleted = await _productRepository.DeleteProduct(id);
            if (isDeleted)
                return new AppResponse(true, "Operation Success.");

            throw new AppException(HttpStatusCode.NotFound, "Product not found.");
        }

        public async Task<AppResponse<ProductDto>> GetProductById(string id)
        {
            var dbProduct = await _productRepository.GetProductById(id);
            if (dbProduct is null)
                throw new AppException(HttpStatusCode.NotFound, "Product not found.");

            var mappedProduct = _mapper.Map<ProductDto>(dbProduct);
            return new AppResponse<ProductDto>(true, mappedProduct, "Operation Success");
        }

        public async Task<AppResponse<IEnumerable<ProductDto>>> GetProducts()
        {
            var dbProducts = await _productRepository.GetProducts();
            if (dbProducts is null)
                throw new AppException(HttpStatusCode.NotFound, "No products found.");

            var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(dbProducts);
            return new AppResponse<IEnumerable<ProductDto>>(true, mappedProducts, "Operation Success");
        }

        public async Task<AppResponse<IEnumerable<ProductDto>>> GetProductsByCategory(string categoryName)
        {
            var dbProducts = await _productRepository.GetProductsByCategory(categoryName);
            if (dbProducts is null)
                throw new AppException(HttpStatusCode.NotFound, "No products found.");

            var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(dbProducts);
            return new AppResponse<IEnumerable<ProductDto>>(true, mappedProducts, "Operation Success.");
        }

        public async Task<AppResponse<IEnumerable<ProductDto>>> GetProductsByName(string name)
        {
            var dbProducts = await _productRepository.GetProductsByName(name);
            if (dbProducts is null)
                throw new AppException(HttpStatusCode.NotFound, "No products found.");

            var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(dbProducts);
            return new AppResponse<IEnumerable<ProductDto>>(true, mappedProducts, "Operation Success.");
        }

        public async Task<AppResponse> UpdateProduct(ProductDto product)
        {
            var productToUpdate = _mapper.Map<Product>(product);
            var isUpdated = await _productRepository.UpdateProduct(productToUpdate);
            if (isUpdated)
                return new AppResponse(true, "Operation Success.");

            throw new AppException(HttpStatusCode.InternalServerError, "Operation fail.");
        }
    }
}
