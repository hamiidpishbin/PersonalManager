using MediatR;
using PM.Common.Domain;

namespace PM.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;