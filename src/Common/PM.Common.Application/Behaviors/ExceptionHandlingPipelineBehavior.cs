using MediatR;
using Microsoft.Extensions.Logging;
using PM.Common.Application.Exceptions;

namespace PM.Common.Application.Behaviors;

public class ExceptionHandlingPipelineBehavior<TRequest, TResponse>
	: IPipelineBehavior<TRequest, TResponse> where TRequest : class
{
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		try
		{
			return await next(cancellationToken);
		}
		catch (Exception exception)
		{
			throw new PersonalManagerException(typeof(TRequest).Name, innerException: exception);
		}
	}
}