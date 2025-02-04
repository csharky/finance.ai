using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Domain.Transactions;

namespace Finance.Ai.Application.Categories;

public class GetCategoryQuery : IQuery<GetCategoryDto>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}