using Application.Products.Commands;
using Domain.Products;
using MediatR;

namespace Application.Products.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {

        #region Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var existData = _productRepository.Get(x => x.Id == request.Id);

            if (existData == null)
                throw new ArgumentNullException("Product doesn't exist");

            _productRepository.Delete(existData);

            return Unit.Value;
        }

        #endregion

    }
}
