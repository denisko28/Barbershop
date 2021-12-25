using System.Linq;
using FluentValidation;
using Barbershop.BLL.DTO.Requests;
using System.Text.RegularExpressions;

namespace Barbershop.BLL.Validation.Requests
{
    public class CustomerSignUpRequestValidator : AbstractValidator<CustomerSignUpRequest>
    {
        public CustomerSignUpRequestValidator()
        {
            RuleFor(request => request.Phone)
                .Must(phone => Regex.IsMatch(phone, @"^0[0-9]{9}$"))
                .WithMessage("Wrong phone number.");

            RuleFor(request => request.Password)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.Password)} can't be empty.")
                .Must(password => !(password is null) && password.Any(char.IsUpper))
                .WithMessage(request => $"{nameof(request.Password)} must contain an uppercase character.")
                .Must(password => !(password is null) && password.Any(char.IsLower))
                .WithMessage(request => $"{nameof(request.Password)} must contain a lowercase character.")
                .Must(password => !(password is null) && password.Any(char.IsDigit))
                .WithMessage(request => $"{nameof(request.Password)} must contain a digit.");

            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.Name)} can't be empty.")
                .MaximumLength(15)
                .WithMessage(request => $"{nameof(request.Name)} should be less than 50 characters.");

            RuleFor(request => request.Surname)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.Surname)} can't be empty.")
                .MaximumLength(20)
                .WithMessage(request => $"{nameof(request.Surname)} should be less than 50 characters.");

            RuleFor(request => request.Patronymic)
                .MaximumLength(20)
                .WithMessage(request => $"{nameof(request.Patronymic)} should be less than 50 characters.");
        }
    }
}
