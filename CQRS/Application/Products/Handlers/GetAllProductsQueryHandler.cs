using Application.Products.Dtos.Response;
using Application.Products.Queries;
using Domain.Products;
using MediatR;

namespace Application.Products.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsQueryResponse>>
    {
        #region Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public GetAllProductsQueryHandler(Domain.Products.IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region Methods

        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetList();

            if (products.Count == 0)
                throw new System.Exception("Products Not Found!");

            var response = new List<GetAllProductsQueryResponse>();

            products.ForEach(x => response.Add(new GetAllProductsQueryResponse
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
            }));

            return response;
        }

        #endregion


    }
}
