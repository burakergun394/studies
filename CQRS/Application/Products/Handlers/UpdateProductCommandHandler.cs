using Application.Products.Commands;
using Application.Products.Dtos.Response;
using AutoMapper;
using Domain.Products;
using MediatR;

namespace Application.Products.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
    {
        #region Fields

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existData = _productRepository.Get(x => x.Id == request.UpdateProductRequest.Id);

            if (existData == null)
                throw new ArgumentNullException("Product doesn't exist");

            existData.SetName(request.UpdateProductRequest.Name);
            existData.SetCode(request.UpdateProductRequest.Code);

            var updatingProduct = _mapper.Map<Product>(existData);

            var updatedProduct = _productRepository.Update(updatingProduct);

            return _mapper.Map<UpdateProductResponse>(updatedProduct);
        }

        #endregion

    }
}
