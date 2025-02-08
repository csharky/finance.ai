using Finance.Ai.Domain.ValueObjects;
using MediatR;

namespace Finance.Ai.Application.Abstractions.Messaging;

public interface ICommand : ICommandBase, IRequest<Result>
{
}

public interface ICommand<TResponse> : ICommandBase, IRequest<Result<TResponse>>
{
}