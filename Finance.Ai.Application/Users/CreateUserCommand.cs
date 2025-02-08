using Finance.Ai.Application.Abstractions.Messaging;

namespace Finance.Ai.Application.Users;

public class CreateUserCommand(string email) : ICommand<CreateUserDto>
{
    public string Email { get; } = email;
}