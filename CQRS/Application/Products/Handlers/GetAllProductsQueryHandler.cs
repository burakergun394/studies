using Application.Products.Dtos.Response;
using Application.Products.Queries;
using AutoMapper;
using Core.CrossCuttinnConcerns.Caching;
using Domain.Products;
using MediatR;

namespace Application.Products.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsQueryResponse>>
    {
        #region Fields

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICache _cache;

        #endregion

        #region Constructor

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper, ICache cache)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cache = cache;
        }

        #endregion

        #region Methods

        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            if (_cache.IsAdd("get-all-products"))
                return (List<GetAllProductsQueryResponse>)_cache.Get("get-all-products");
            
            var products = _productRepository.GetList();

            if (products.Count == 0)
                throw new System.Exception("Products Not Found!");

            var result = _mapper.Map<List<GetAllProductsQueryResponse>>(products);

            _cache.Add("get-all-products", result, 30);

            return result;
        }

        #endregion


    }
}
