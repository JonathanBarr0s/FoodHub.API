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
				.Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Name is required")
				.NotEqual("string").WithMessage("Name must be valid");

			RuleFor(x => x.Price)
				.NotEmpty().WithMessage("Price is required")
				.GreaterThan(0).WithMessage("Price must be greater than zero");

			RuleFor(x => x.RestaurantId)
				.NotEmpty().WithMessage("RestaurantId is required")
				.GreaterThan(0).WithMessage("RestaurantId must be valid");
		}
	}
}
