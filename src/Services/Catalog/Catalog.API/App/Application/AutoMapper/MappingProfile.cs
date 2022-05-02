using AutoMapper;
using Catalog.API.App.Application.Dto;
using Catalog.API.App.Domain.Entities;

namespace Catalog.API.App.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();
        }
    }
}
