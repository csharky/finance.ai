using Finance.Ai.Application.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Ai.Presentation.Controllers;

[Route("api/user")]
public class UserController : ApiController
{
    public UserController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        
        if (result.IsSuccess) return Ok(result.Value);
        
        return BadRequest(result.Error);
    }
}