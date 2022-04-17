using Application.Products.Commands;
using Application.Products.Dtos.Response;
using AutoMapper;
using Domain.Products;
using MediatR;

namespace Application.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
    {
        #region Fields

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var addingProduct = _mapper.Map<Product>(request.CreateProductRequest);

            var addedProduct = _productRepository.Insert(addingProduct);

            return _mapper.Map<CreateProductResponse>(addedProduct);
        }

        #endregion

    }
}
