using FluentValidation;
using FoodHub.API.Dtos.Dish;

namespace FoodHub.API.Services.Validators
{
	public class DishCreateValidator : AbstractValidator<DishCreateDto>
	{
		public DishCreateValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required")
				.MaximumLength(100).WithMessage("Name must be less than 100 characters");

			RuleFor(x => x.Price)
				.GreaterThan(0).WithMessage("Price must be greater than zero");

			RuleFor(x => x.RestaurantId)
				.GreaterThan(0).WithMessage("RestaurantId must be valid");
		}
	}
}
