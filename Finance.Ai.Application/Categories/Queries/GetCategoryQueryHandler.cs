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
}