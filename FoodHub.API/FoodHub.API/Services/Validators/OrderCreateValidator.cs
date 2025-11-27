using FluentValidation;
using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.Order;

namespace FoodHub.API.Services.Validators
{
	public class OrderCreateValidator : AbstractValidator<OrderCreateDto>
	{
		public OrderCreateValidator()
		{
			RuleFor(x => x.UserId)
				.NotEmpty().WithMessage("User is required.");

			RuleFor(x => x.RestaurantId)
				.NotEmpty().WithMessage("Restaurant is required.");			
		}
	}
}
