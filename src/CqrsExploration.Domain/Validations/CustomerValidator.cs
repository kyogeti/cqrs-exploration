using System;
using CqrsExploration.Domain.Entities;
using FluentValidation;

namespace CqrsExploration.Domain.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {

            RuleFor(x => x.Id)
                .NotNull()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CreatedAt)
                .Must(x => x > DateTime.MinValue);

        }
    }
}