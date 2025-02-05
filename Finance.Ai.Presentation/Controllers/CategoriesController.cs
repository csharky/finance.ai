using Finance.Ai.Application.Categories;
using Finance.Ai.Application.Categories.Commands;
using Finance.Ai.Application.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Ai.Presentation.Controllers;

[Route("api/categories")]
public class CategoriesController : ApiController
{
    public CategoriesController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        
        if (result.IsSuccess) return Ok(result.Value);
        
        return BadRequest(result.Error);
    }
    
    [HttpGet]
    [Route("fetchAll")]
    public async Task<IActionResult> Create(Guid userId, CancellationToken cancellationToken)
    {
        var query = new FetchAllCategoriesQuery()
        {
            UserId = userId
        };
        
        var result = await Sender.Send(query, cancellationToken);
        
        if (result.IsSuccess) return Ok(result.Value);
        
        return BadRequest(result.Error);
    }
    
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> Create(Guid id, Guid userId, CancellationToken cancellationToken)
    {
        var query = new GetCategoryQuery()
        {
            Id = id,
            UserId = userId
        };
        
        var result = await Sender.Send(query, cancellationToken);
        
        if (result.IsSuccess) return Ok(result.Value);
        
        return BadRequest(result.Error);
    }
}