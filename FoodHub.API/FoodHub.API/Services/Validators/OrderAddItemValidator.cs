using FluentValidation;
using FoodHub.API.Dtos.Order;

namespace FoodHub.API.Services.Validators
{
	public class OrderAddItemValidator : AbstractValidator<OrderAddItemDto>
	{
		public OrderAddItemValidator()
		{
			RuleFor(x => x.DishId)
				.NotEmpty().WithMessage("DishId is required")
				.GreaterThan(0).WithMessage("DishId must be valid");

			RuleFor(x => x.Quantity)
				.NotEmpty().WithMessage("Quantity is required")
				.GreaterThan(0).WithMessage("Quantity must be valid");
		}
	}
}
