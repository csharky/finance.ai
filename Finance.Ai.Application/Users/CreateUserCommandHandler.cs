using Finance.Ai.Application.Abstractions;
using Finance.Ai.Domain.Abstractions;
using Finance.Ai.Domain.Users;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Application.Users;

internal sealed class CreateUserCommandHandler(
    IUsersRepository usersRepository, 
    IUnitOfWork unitOfWork) : ICommandHandler<CreateUserCommand, UserDto>
{
    public async Task<Result<UserDto>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var email = Email.Create(command.Email);
        
        var user = await usersRepository.GetByEmailAsync(email);
        if (user != null)
        {
            throw new Exception("User already exists with this email");
        }

        user = await usersRepository.CreateAsync(Guid.NewGuid(), email);
        
        await unitOfWork.SaveChangesAsync();

        var userDto = new UserDto()
        {
            Id = user.Id,
            Email = user.Email.Value
        };
        
        return Result<UserDto>.Success(userDto);
    }
}