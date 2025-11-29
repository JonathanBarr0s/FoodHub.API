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
				.NotEqual("string").WithMessage("FullName must be valid")
				.Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("FullName is required");

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email is required")
				.NotEqual("string").WithMessage("Email must be valid")
				.Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Email is required")
				.EmailAddress().WithMessage("Email must be valid");

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Password is required")
				.NotEqual("string").WithMessage("Password must be valid")
				.Must(x => x != null && x.Trim().Length >= 5 && x.Trim().Length <= 15)
					.WithMessage("The password must be between 5 and 15 characters long.");
		}
	}
}
