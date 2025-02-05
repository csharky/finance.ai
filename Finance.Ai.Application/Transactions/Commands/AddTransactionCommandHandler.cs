using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Application.Transactions.Dto;
using Finance.Ai.Domain.Abstractions;
using Finance.Ai.Domain.Models.Transactions;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Application.Transactions.Commands;

internal sealed class AddTransactionCommandHandler(
    ITransactionsRepository transactionsRepository, 
    IUnitOfWork unitOfWork) 
    : ICommandHandler<AddTransactionCommand, AddTransactionDto>
{
    public async Task<Result<AddTransactionDto>> Handle(AddTransactionCommand command, CancellationToken cancellationToken)
    {
        var transaction = await transactionsRepository.AddAsync(command.UserId, command.CategoryId, command.TransactionTime, command.Name, command.Amount, cancellationToken);

        if (transaction == null)
        {
            return Result<AddTransactionDto>.Fail("Transaction was not created");
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var categoryDto = new AddTransactionDto()
        {
            Id = transaction.Id,
            CategoryId = transaction.CategoryId,
            Name = transaction.Name,
            Amount = transaction.Amount,
        };
        
        return Result<AddTransactionDto>.Success(categoryDto);
    }
}