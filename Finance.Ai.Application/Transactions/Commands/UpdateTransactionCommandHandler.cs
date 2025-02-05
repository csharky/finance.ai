using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Application.Transactions.Dto;
using Finance.Ai.Domain.Abstractions;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Application.Transactions.Commands;

internal sealed class UpdateTransactionCommandHandler(
    ITransactionsRepository transactionsRepository, 
    IUnitOfWork unitOfWork) 
    : ICommandHandler<UpdateTransactionCommand, UpdateTransactionDto>
{
    public async Task<Result<UpdateTransactionDto>> Handle(UpdateTransactionCommand command, CancellationToken cancellationToken)
    {
        var transaction = await transactionsRepository.GetAsync(command.Id, cancellationToken);
        if (transaction == null)
        {
            return Result<UpdateTransactionDto>.Fail("Transaction does not exist");
        }
        
        transaction.Update(command.CategoryId, transaction.Time, command.Name, command.Amount);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var categoryDto = new UpdateTransactionDto()
        {
            Id = transaction.Id,
            CategoryId = transaction.CategoryId,
            Name = transaction.Name,
            Amount = transaction.Amount,
        };
        
        return Result<UpdateTransactionDto>.Success(categoryDto);
    }
}