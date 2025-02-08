using Finance.Ai.Application.Categories.Commands;
using Finance.Ai.Application.Categories.Queries;
using Finance.Ai.Presentation.Categories.Requests;
using Finance.Ai.Presentation.Controllers;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Ai.Presentation.Categories;

[Route("api/categories")]
public class CategoriesController : ApiController
{
    public CategoriesController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(
        CreateCategoryRequest request, 
        IValidator<CreateCategoryCommand> validator,
        CancellationToken cancellationToken)
    {
        var command = new CreateCategoryCommand(request.Name, request.UserId);
        var result = await Sender.Send(command, cancellationToken);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        
        return BadRequest(new { message = result.Error });
    }
    
    [HttpGet]
    [Route("fetchAll")]
    public async Task<IActionResult> FetchAll(Guid userId, CancellationToken cancellationToken)
    {
        var query = new FetchAllCategoriesQuery()
        {
            UserId = userId
        };
        
        var result = await Sender.Send(query, cancellationToken);
        
        if (result.IsSuccess) return Ok(result.Value);
        
        return BadRequest(new { message = result.Error });
    }
    
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> Get(Guid id, Guid userId, CancellationToken cancellationToken)
    {
        var query = new GetCategoryQuery()
        {
            Id = id,
            UserId = userId
        };
        
        var result = await Sender.Send(query, cancellationToken);
        
        if (result.IsSuccess) return Ok(result.Value);
        
        return BadRequest(new { message = result.Error });
    }
}