using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Application.Categories.Dto;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Application.Categories.Queries;

public class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, GetCategoryDto>
{
    private readonly ICategoriesRepository _categoriesRepository;
    
    public GetCategoryQueryHandler(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }
    
    public async Task<Result<GetCategoryDto>> Handle(
        GetCategoryQuery? request, CancellationToken cancellationToken)
    {
        var validateRequest = ValidateRequest(request);
        if (validateRequest.IsFailed) return validateRequest;

        var category = await _categoriesRepository.GetByIdAsync(request!.Id, cancellationToken);

        if (category?.UserId != request.UserId)
        {
            throw new UnauthorizedAccessException();
        }

        var dto = new GetCategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
        
        return Result<GetCategoryDto>.Success(dto);
    }

    private static Result<GetCategoryDto> ValidateRequest(GetCategoryQuery? request)
    {
        if (request == null)
        {
            return Result<GetCategoryDto>.Fail($"{nameof(request)} is empty");
        }

        if (request.UserId == Guid.Empty)
        {
            return Result<GetCategoryDto>.Fail($"{nameof(request.UserId)} is empty");
        }

        if (request.Id == Guid.Empty)
        {
            return Result<GetCategoryDto>.Fail($"{nameof(request.Id)} is empty");
        }

        return Result<GetCategoryDto>.Success(null);
    }
}