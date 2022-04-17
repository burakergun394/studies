using Application.Products.Dtos.Request;
using Application.Products.Dtos.Response;
using MediatR;

namespace Application.Products.Commands
{
    public class CreateProductCommand: IRequest<CreateProductResponse>
    {
        public CreateProductRequest CreateProductRequest { get; set; }

        public CreateProductCommand(CreateProductRequest createProductRequest)
        {
            CreateProductRequest = createProductRequest;
        }
    }
}
