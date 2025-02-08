using Finance.Ai.Application.Categories.Queries;
using Finance.Ai.Application.Transactions.Commands;
using Finance.Ai.Application.Transactions.Queries;
using Finance.Ai.Presentation.Controllers;
using Finance.Ai.Presentation.Transactions.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Ai.Presentation.Transactions;

[Route("api/transactions")]
public class TransactionsController : ApiController
{
    public TransactionsController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody] AddTransactionRequest request, CancellationToken cancellationToken)
    {
        var command = new AddTransactionCommand(request.UserId, request.CategoryId, request.TransactionTime.ToUniversalTime(), request.Name, request.Amount);
        var result = await Sender.Send(command, cancellationToken);
        
        if (result.IsSuccess) return Ok(result.Value);
        
        return BadRequest(new { message = result.Error });
    }
    
    [HttpGet]
    [Route("fetchAll")]
    public async Task<IActionResult> FetchAll(Guid userId, CancellationToken cancellationToken)
    {
        var query = new FetchAllTransactionsQuery()
        {
            UserId = userId
        };
        
        var result = await Sender.Send(query, cancellationToken);
        
        if (result.IsSuccess) return Ok(result.Value);
        
        return BadRequest(new { message = result.Error });
    }
}