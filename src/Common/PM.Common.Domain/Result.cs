using System.Diagnostics.CodeAnalysis;

namespace PM.Common.Domain;

public class Result
{
	public bool IsSuccess { get; }
	public Error Error { get; }
	public bool IsFailure => !IsSuccess;
	
	public Result(bool isSuccess, Error error)
	{
		if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
		{
			throw new ArgumentException("Invalid error!", nameof(error));
		}

		IsSuccess = isSuccess;
		Error = error;
	}

	public static Result Success() => new(true, Error.None);

	public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

	public static Result Failure(Error error) => new(false, error);

	public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
}

public class Result<TValue>(TValue? value, bool isSuccess, Error error) : Result(isSuccess, error)
{
	[NotNull]
	public TValue Value => IsSuccess
		? value!
		: throw new InvalidOperationException("The value of a failure result can't be accessed.");
	
	public static implicit operator Result<TValue>(TValue? value)
	{
		return value is not null
			? Success(value)
			: Failure<TValue>(Error.NullValue);
	}

	public static Result<TValue> ValidationFailure(Error error)
	{
		return new Result<TValue>(default, false, error);
	}
}