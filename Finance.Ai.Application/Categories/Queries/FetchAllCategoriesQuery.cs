using Finance.Ai.Application.Abstractions.Messaging;

namespace Finance.Ai.Application.Categories;

public class FetchAllCategoriesQuery : IQuery<FetchAllCategoriesDto>
{
    public Guid UserId { get; set; }
}