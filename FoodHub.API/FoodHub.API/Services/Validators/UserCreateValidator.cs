using FluentValidation;
using FoodHub.API.Dtos.User;

namespace FoodHub.API.Services.Validators
{
	public class UserCreateValidator : AbstractValidator<UserCreateDto>
	{
		public UserCreateValidator()
		{
			RuleFor(x => x.FullName)
				.NotEmpty().WithMessage("FullName is required")
				.MaximumLength(100).WithMessage("FullName must be less than 100 characters");

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email is required")
				.EmailAddress().WithMessage("Invalid email format");

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Password is required");
		}
	}
}