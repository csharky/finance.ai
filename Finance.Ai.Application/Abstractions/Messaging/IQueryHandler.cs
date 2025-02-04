using Finance.Ai.Domain.ValueObjects;
using MediatR;

namespace Finance.Ai.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}