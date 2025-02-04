using Finance.Ai.Application.Abstractions;
using Finance.Ai.Application.Abstractions.Messaging;

namespace Finance.Ai.Application.Users;

public class CreateUserCommand : ICommand<CreateUserDto>
{
    public string Email { get; set; }
}