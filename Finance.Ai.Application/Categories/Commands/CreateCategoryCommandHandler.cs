using Finance.Ai.Application.Abstractions;
using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Domain.Abstractions;
using Finance.Ai.Domain.Users;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Application.Categories;

internal sealed class CreateCategoryCommandHandler(
    ICategoriesRepository categoriesRepository, 
    IUsersRepository usersRepository,
    IUnitOfWork unitOfWork) 
    : ICommandHandler<CreateCategoryCommand, CreateCategoryDto>
{
    public async Task<Result<CreateCategoryDto>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var user = await usersRepository.GetByIdAsync(command.UserId, cancellationToken);
        if (user == null)
        {
            throw new Exception("User does not exist");
        }
        
        var category = await categoriesRepository.CreateAsync(
            Guid.NewGuid(), 
            user.Id,
            command.Name, 
            cancellationToken);

        if (category == null)
        {
            throw new Exception("Category was not created");
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var categoryDto = new CreateCategoryDto()
        {
            Id = category.Id,
            Name = category.Name,
        };
        
        return Result<CreateCategoryDto>.Success(categoryDto);
    }
}