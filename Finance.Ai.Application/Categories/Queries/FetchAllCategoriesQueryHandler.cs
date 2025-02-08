using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Application.Categories.Dto;
using Finance.Ai.Domain.Users;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Application.Categories.Queries;

public class FetchAllCategoriesQueryHandler : IQueryHandler<FetchAllCategoriesQuery, FetchAllCategoriesDto>
{
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IUsersRepository _usersRepository;
    
    public FetchAllCategoriesQueryHandler(ICategoriesRepository categoriesRepository, IUsersRepository usersRepository)
    {
        _categoriesRepository = categoriesRepository;
        _usersRepository = usersRepository;
    }
    
    public async Task<Result<FetchAllCategoriesDto>> Handle(
        FetchAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user == null)
        {
            return Result<FetchAllCategoriesDto>.Fail("User does not exist");
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