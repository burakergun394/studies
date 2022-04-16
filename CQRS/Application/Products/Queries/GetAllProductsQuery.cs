using Application.Products.Dtos.Response;
using MediatR;

namespace Application.Products.Queries
{
    public class GetAllProductsQuery: IRequest<List<GetAllProductsQueryResponse>>
    {

    }
}
