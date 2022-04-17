using Application.Products.Dtos.Request;
using Application.Products.Dtos.Response;
using MediatR;

namespace Application.Products.Commands
{
    public class UpdateProductCommand : IRequest<UpdateProductResponse>
    {
        #region Fields

        public UpdateProductRequest UpdateProductRequest { get; set; }

        #endregion

        #region Constructors

        public UpdateProductCommand(UpdateProductRequest updateProductRequest)
        {
            UpdateProductRequest = updateProductRequest;
        }

        #endregion
    }
}
