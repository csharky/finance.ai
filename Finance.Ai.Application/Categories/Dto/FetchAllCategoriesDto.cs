namespace Finance.Ai.Application.Categories.Dto;

public class FetchAllCategoriesDto
{
    public IReadOnlyList<CategoryDto> Categories { get; set; }
    
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}