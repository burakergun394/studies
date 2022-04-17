using MediatR;

namespace Application.Products.Commands
{
    public class DeleteProductCommand: IRequest<Unit>
    {
        #region Fields

        public int Id { get; private set; }

        #endregion

        #region Constructors

        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        #endregion
    }
}
