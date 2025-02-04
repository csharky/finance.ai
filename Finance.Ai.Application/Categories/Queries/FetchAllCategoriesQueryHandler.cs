using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Application.Categories.Queries;

public class FetchAllCategoriesQueryHandler : IQueryHandler<FetchAllCategoriesQuery, FetchAllCategoriesDto>
{
    private readonly ICategoriesRepository _categoriesRepository;
    
    public FetchAllCategoriesQueryHandler(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }
    
    public async Task<Result<FetchAllCategoriesDto>> Handle(
        FetchAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (request.UserId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(request.UserId));
        }

        var categories = await _categoriesRepository.FetchAllAsync(request.UserId, cancellationToken);
        var dto = new FetchAllCategoriesDto
        {
            Categories = categories
                .Select(category => new FetchAllCategoriesDto.CategoryDto()
                {
                    Id = category.Id,
                    Name = category.Name,
                })
                .ToArray()
        };
            
        return Result<FetchAllCategoriesDto>.Success(dto);
    }
}