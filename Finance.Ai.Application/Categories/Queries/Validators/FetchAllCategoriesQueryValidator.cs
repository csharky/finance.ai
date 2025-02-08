using FluentValidation;

namespace Finance.Ai.Application.Categories.Queries.Validators;

public class FetchAllCategoriesQueryValidator : AbstractValidator<FetchAllCategoriesQuery>
{
    public FetchAllCategoriesQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");
    }
} 