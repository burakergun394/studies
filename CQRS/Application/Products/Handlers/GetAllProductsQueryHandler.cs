using Application.Products.Dtos.Response;
using Application.Products.Queries;
using AutoMapper;
using Domain.Products;
using MediatR;

namespace Application.Products.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsQueryResponse>>
    {
        #region Fields

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetList();

            if (products.Count == 0)
                throw new System.Exception("Products Not Found!");
 

            return _mapper.Map<List<GetAllProductsQueryResponse>>(products);
        }

        #endregion


    }
}
