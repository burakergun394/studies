using Application.Products.Dtos.Request;
using Application.Products.Dtos.Response;
using AutoMapper;
using Domain.AggregateRoots;
using Domain.Products;

namespace Application.Products.Mappings.AutoMapper
{
    public class ProductProfile: Profile
    {
        #region Constructors

        public ProductProfile()
        {
            CreateMap<Product, GetAllProductsQueryResponse>();

            CreateMap<CreateProductRequest, Product>()
                .ForMember(dest => dest.CreatedTime, src => src.MapFrom(prop => DateTime.Now));
            CreateMap<Product, CreateProductResponse>();

            CreateMap<Product, UpdateProductResponse>();
            CreateMap<Product, Product>();
        }

        #endregion
    }
}
