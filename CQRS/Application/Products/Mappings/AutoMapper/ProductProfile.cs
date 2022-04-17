using Application.Products.Dtos.Request;
using Application.Products.Dtos.Response;
using AutoMapper;
using Domain.Products;

namespace Application.Products.Mappings.AutoMapper
{
    public class ProductProfile: Profile
    {
        #region Constructors

        public ProductProfile()
        {
            CreateMap<Product, GetAllProductsQueryResponse>();

            CreateMap<CreateProductRequest, Product>();
            CreateMap<CreateProductRequest, Product>()
                .ForMember(dest => dest.CreatedTime, src => src.MapFrom(prop => DateTime.Now));
            CreateMap<Product, CreateProductResponse>();
        }

        #endregion
    }
}
