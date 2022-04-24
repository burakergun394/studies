using Application.Products.Commands;
using Application.Products.Dtos.Request;
using FluentValidation;

namespace Application.Products.Validators
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.CreateProductRequest.Code)
               .NotEmpty()
               .WithMessage("Code is required");

            RuleFor(x => x.CreateProductRequest.Name)
                .NotEmpty()
                .WithMessage("Name is required");
        }
    }
}
