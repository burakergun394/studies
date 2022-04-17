using Application.Products.Dtos.Request;
using Application.Products.Dtos.Response;
using MediatR;

namespace Application.Products.Commands
{
    public class CreateProductCommand: IRequest<CreateProductResponse>
    {
        #region Fields

        public CreateProductRequest CreateProductRequest { get; set; }

        #endregion

        #region Constructors

        public CreateProductCommand(CreateProductRequest createProductRequest)
        {
            CreateProductRequest = createProductRequest;
        }

        #endregion
    }
}
