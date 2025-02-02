using Finance.Ai.Domain.ValueObjects;
using MediatR;

namespace Finance.Ai.Application.Abstractions;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}