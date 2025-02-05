using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Application.Categories.Dto;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Application.Categories.Queries;

public class FetchAllTransactionsByUserIdQueryHandler : IQueryHandler<FetchAllCategoriesQuery, FetchAllCategoriesDto>
{
    private readonly ICategoriesRepository _categoriesRepository;
    
    public FetchAllTransactionsByUserIdQueryHandler(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }
    
    public async Task<Result<FetchAllCategoriesDto>> Handle(
        FetchAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        if (request.UserId == Guid.Empty)
        {
            return Result<FetchAllCategoriesDto>.Fail($"{nameof(request.UserId)} is empty");
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