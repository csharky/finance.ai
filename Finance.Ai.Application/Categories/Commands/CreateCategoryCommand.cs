using Finance.Ai.Application.Abstractions;
using Finance.Ai.Application.Abstractions.Messaging;

namespace Finance.Ai.Application.Categories;

public class CreateCategoryCommand : ICommand<CreateCategoryDto>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
}