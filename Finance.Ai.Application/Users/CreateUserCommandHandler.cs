using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Domain.Abstractions;
using Finance.Ai.Domain.Users;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Application.Users;

internal sealed class CreateUserCommandHandler(IUsersRepository usersRepository, IUnitOfWork unitOfWork) 
    : ICommandHandler<CreateUserCommand, CreateUserDto>
{
    public async Task<Result<CreateUserDto>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var email = Email.Create(command.Email);
        
        var user = await usersRepository.GetByEmailAsync(email, cancellationToken);
        if (user != null)
        {
            return Result<CreateUserDto>.Fail("User already exists with this email");
        }

        user = await usersRepository.CreateAsync(Guid.NewGuid(), email, cancellationToken);

        if (user == null)
        {
            return Result<CreateUserDto>.Fail("User was not created");
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var userDto = new CreateUserDto()
        {
            Id = user.Id,
            Email = user.Email.Value
        };
        
        return Result<CreateUserDto>.Success(userDto);
    }
}