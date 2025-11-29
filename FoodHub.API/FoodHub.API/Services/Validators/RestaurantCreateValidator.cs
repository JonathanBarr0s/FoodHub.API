using FluentValidation;
using FoodHub.API.Dtos.Restaurant;

namespace FoodHub.API.Services.Validators
{
	public class RestaurantCreateValidator : AbstractValidator<RestaurantCreateDto>
	{
		public RestaurantCreateValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required")
				.Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Name is required")
				.NotEqual("string").WithMessage("Name must be valid");

			RuleFor(x => x.Address)
				.NotEmpty().WithMessage("Address is required")
				.Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Address is required")
				.NotEqual("string").WithMessage("Address must be valid");
		}
	}
}