using Finance.Ai.Domain.ValueObjects;
using MediatR;

namespace Finance.Ai.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}