using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Application.Categories;

public class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, GetCategoryDto>
{
    private readonly ICategoriesRepository _categoriesRepository;
    
    public GetCategoryQueryHandler(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }
    
    public async Task<Result<GetCategoryDto>> Handle(
        GetCategoryQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (request.UserId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(request.UserId));
        }

        if (request.Id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(request.Id));
        }

        var category = await _categoriesRepository.GetByIdAsync(request.Id, cancellationToken);

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