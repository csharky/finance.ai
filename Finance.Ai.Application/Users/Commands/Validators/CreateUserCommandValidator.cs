using Finance.Ai.Domain.ValueObjects;
using FluentValidation;

namespace Finance.Ai.Application.Users.Commands.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .DependentRules(() => 
                RuleFor(x => x.Email)
                    .Must(Email.IsValid)
                    .WithMessage("Email is invalid"));
    }
} 