using FluentValidation;
using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.OrderItem;

namespace FoodHub.API.Services.Validators
{
	//public class OrderItemCreateValidator : AbstractValidator<OrderItemCreateDto>
	//{
	//	public OrderItemCreateValidator()
	//	{
	//		RuleFor(x => x.DishId)
	//			.NotEmpty().WithMessage("Dish is required.");

	//		RuleFor(x => x.Quantity)
	//			.GreaterThan(0).WithMessage("The quantity must be greater than zero.");
	//	}
	//}
}