using MediatR;
using PM.Common.Domain;

namespace PM.Common.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse> 
	: IRequestHandler<TQuery, Result<TResponse>> 
	where TQuery : IQuery<TResponse>;