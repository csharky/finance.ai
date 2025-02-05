using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Application.Categories.Dto;

namespace Finance.Ai.Application.Categories.Queries;

public class FetchAllTransactionsByUserIdQuery : IQuery<FetchAllCategoriesDto>
{
    public Guid UserId { get; set; }
}