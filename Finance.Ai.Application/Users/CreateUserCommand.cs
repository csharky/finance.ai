using Finance.Ai.Application.Abstractions;

namespace Finance.Ai.Application.Users;

public class CreateUserCommand : ICommand<UserDto>
{
    public string Email { get; set; }
}