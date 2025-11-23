using eCommerce.Core.DTOs;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterDTO>
{
    public RegisterRequestValidator()
    {
        RuleFor(req => req.Email)
            .NotEmpty().WithMessage("Email address is required.")
            .EmailAddress().WithMessage("Email address is not in the correct format")
            .Must(CustomValidators.BeValidEmail).WithMessage("Invalid email address");

        RuleFor(req => req.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .Matches("^[0-9]*$").WithMessage("Phone number must contain only digits")
            .Length(11).WithMessage("Phone number must be exactly 11 digits.")
            .Must(CustomValidators.BeValidPhone).WithMessage("Invalid phone number");

        RuleFor(req => req.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");

        RuleFor(req => req.ConfirmPassword)
             .NotEmpty().WithMessage("Confirm password is required")
             .MinimumLength(6).WithMessage("Confirm password must be at least 6 characters")
             .Equal(req => req.Password).WithMessage("Password and its confirmation are not same");

        RuleFor(req => req.PersonName)
            .NotEmpty().WithMessage("Person name is required.")
            .Length(3, 40).WithMessage("Person name must be between 3 and 40 characters");

        RuleFor(req => req.Gender)
            .NotEmpty().WithMessage("Gender is required")
            .IsInEnum().WithMessage("Invalid gender");
    }
}

