using FluentValidation;

namespace PM.DTM.Application.Sprints.Add;

public class AddSprintCommandValidator : AbstractValidator<AddSprintCommand>
{
	public AddSprintCommandValidator()
	{
		RuleFor(p => p.Name)
			.NotNull()
			.NotEmpty()
			.WithMessage("Name property cannot be null or empty.");

		RuleFor(p => p.StartDate)
			.LessThan(p => p.EndDate)
			.WithMessage("Start date should be smaller than end date.");
	}
}