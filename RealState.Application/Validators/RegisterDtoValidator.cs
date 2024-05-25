using FluentValidation;
using RealState.Application.Contracts.Models;

namespace RealState.Application.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(a => a.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Length(11).WithMessage("Phone number must be 11 characters long.")
                .Matches("^[0-9]*$").WithMessage("Phone number must contain only numeric characters.")
                .When(a => !string.IsNullOrEmpty(a.PhoneNumber));

            RuleFor(s => s.SSN)
                .NotEmpty().WithMessage("SSN is required.")
                .Length(14).WithMessage("SSN must be exactly 14 digits long.");

            RuleFor(n => n.Email)
                .NotEmpty().WithMessage(" Email is Required.")
                .EmailAddress().WithMessage("Email is not a valid email address.");

        }
    }
}
