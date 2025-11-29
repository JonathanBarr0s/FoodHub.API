using FluentValidation;
using FoodHub.API.Dtos.Restaurant;
using System.Net;

namespace FoodHub.API.Services.Validators
{
	public class RestaurantUpdateValidator : AbstractValidator<RestaurantUpdateDto>
	{
		public RestaurantUpdateValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required")
				.NotEqual("string").WithMessage("Name must be valid");

			RuleFor(x => x.Address)
				.NotEmpty().WithMessage("Address is required")
				.Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Address is required")
				.NotEqual("string").WithMessage("Address must be valid");
		}
	}
}