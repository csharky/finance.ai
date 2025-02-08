using Finance.Ai.Application.Users;
using Finance.Ai.Presentation.Controllers;
using Finance.Ai.Presentation.Users.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Ai.Presentation.Users;

[Route("api/users")]
public class UsersController : ApiController
{
    public UsersController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(request.Email);
        var result = await Sender.Send(command, cancellationToken);
        
        if (result.IsSuccess) return Ok(result.Value);
        
        return BadRequest(new { message = result.Error });
    }
}