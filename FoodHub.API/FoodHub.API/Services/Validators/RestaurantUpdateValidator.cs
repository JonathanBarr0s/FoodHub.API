using FluentValidation;
using FoodHub.API.Dtos.Restaurant;

namespace FoodHub.API.Services.Validators
{
	public class RestaurantUpdateValidator : AbstractValidator<RestaurantUpdateDto>
	{
		public RestaurantUpdateValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required")
				.MaximumLength(100).WithMessage("Name must be less than 100 characters");

			RuleFor(x => x.Address)
				.NotEmpty().WithMessage("Address is required")
				.MaximumLength(200).WithMessage("Address must be less than 200 characters");
		}
	}
}