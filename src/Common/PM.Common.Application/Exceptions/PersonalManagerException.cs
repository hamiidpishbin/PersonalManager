using PM.Common.Domain;

namespace PM.Common.Application.Exceptions;

public sealed class PersonalManagerException(
	string requestName,
	Error? error = null,
	Exception? innerException = null)
	: Exception("Application exception", innerException)
{
	public string RequestName { get; } = requestName;

	public Error? Error { get; } = error;
}