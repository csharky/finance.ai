using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Application.Categories.Dto;

namespace Finance.Ai.Application.Categories.Queries;

public class GetCategoryQuery : IQuery<GetCategoryDto>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}