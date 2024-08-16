using FluentValidation;

namespace Restaurants.Application.Commands.CreateDish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(dish => dish.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be a non-negative number.");

            RuleFor(dish => dish.KiloCaloriess)
                .GreaterThanOrEqualTo(0)
                .WithMessage("kilo must be a non-negative number ");
        }
    }
}
