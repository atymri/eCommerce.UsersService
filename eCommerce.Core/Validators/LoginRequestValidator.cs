using eCommerce.Core.DTOs;
using FluentValidation;
using eCommerce.Core.Validators;

namespace eCommerce.Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginDTO>
{
    public LoginRequestValidator()
    {
        RuleFor(req => req.Email)
            .NotEmpty().WithMessage("Email address is required.")
            .EmailAddress().WithMessage("Email address is not in the correct format")
            .Must(CustomValidators.BeValidEmail);

        RuleFor(req => req.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");
    }
}
