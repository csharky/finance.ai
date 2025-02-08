using FluentValidation;

namespace Finance.Ai.Application.Categories.Queries.Validators;

public class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery>
{
    public GetCategoryQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
} 