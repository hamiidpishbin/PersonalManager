using Microsoft.AspNetCore.Http;
using PM.Common.Domain;

namespace PM.Common.Presentation.Results;

public static class ApiResults
{
	public static IResult Problem(Result result)
	{
		if (result.IsSuccess)
		{
			throw new InvalidOperationException();
		}

		return Microsoft.AspNetCore.Http.Results.Problem(
			title: GetTitle(result.Error),
			detail: GetDetail(result.Error),
			type: GetType(result.Error.Type),
			statusCode: GetStatusCode(result.Error.Type),
			extensions: GetErrors(result));

	}
	
	private static string GetTitle(Error error)
	{
		return error.Type switch
		{
			ErrorType.Validation => error.Code,
			ErrorType.Problem => error.Code,
			ErrorType.NotFound => error.Code,
			ErrorType.Conflict => error.Code,
			_ => "Server failure"
		};
	}
	
	private static string GetDetail(Error error)
	{
		return error.Type switch
		{
			ErrorType.Validation => error.Description,
			ErrorType.Problem => error.Description,
			ErrorType.NotFound => error.Description,
			ErrorType.Conflict => error.Description,
			_ => "An unexpected error occurred"
		};
	}
	
	private static string GetType(ErrorType errorType)
	{
		return errorType switch
		{
			ErrorType.Validation => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
			ErrorType.Problem => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
			ErrorType.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
			ErrorType.Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
			_ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
		};
	}
	
	private static int GetStatusCode(ErrorType errorType)
	{
		return errorType switch
		{
			ErrorType.Validation => StatusCodes.Status400BadRequest,
			ErrorType.Problem => StatusCodes.Status400BadRequest,
			ErrorType.NotFound => StatusCodes.Status404NotFound,
			ErrorType.Conflict => StatusCodes.Status409Conflict,
			_ => StatusCodes.Status500InternalServerError
		};
	}
	
	private static Dictionary<string, object?>? GetErrors(Result result)
	{
		if (result.Error is not ValidationError validationError)
		{
			return null;
		}

		return new Dictionary<string, object?>
		{
			{ "errors", validationError.Errors }
		};
	}
}