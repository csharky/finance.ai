using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Application.Categories.Dto;

namespace Finance.Ai.Application.Categories.Commands;

public class CreateCategoryCommand(string name, Guid userId) : ICommand<CreateCategoryDto>
{
    public Guid UserId { get; private init; } = userId;
    public string Name { get; private init; } = name;
}