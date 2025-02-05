using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Application.Categories.Dto;

namespace Finance.Ai.Application.Categories.Commands;

public class CreateCategoryCommand : ICommand<CreateCategoryDto>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
}