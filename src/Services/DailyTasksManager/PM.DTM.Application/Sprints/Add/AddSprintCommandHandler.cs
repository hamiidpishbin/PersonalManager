using PM.Common.Application.Abstractions.Authentication;
using PM.Common.Application.Messaging;
using PM.Common.Domain;
using PM.DTM.Application.Abstractions.Data;
using PM.DTM.Application.Abstractions.Repositories;
using PM.DTM.Domain.Models.Sprints;

namespace PM.DTM.Application.Sprints.Add;

public class AddSprintCommandHandler(
	ISprintRepository sprintRepository,
	IUnitOfWork unitOfWork) : ICommandHandler<AddSprintCommand, string>
{
	public async Task<Result<string>> Handle(AddSprintCommand request, CancellationToken cancellationToken)
	{
		var sprint = Sprint.Create(request.Name, request.StartDate, request.EndDate);

		await sprintRepository.InsertAsync(sprint, cancellationToken);

		var isSaveSuccess = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

		return isSaveSuccess
			? Result.Success<string>($"Sprint {sprint.Name} was created successfully.")
			: Result.Failure<string>(Error.Failure("Not successful", "Failed saving new sprint."));
	}
}