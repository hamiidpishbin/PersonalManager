using PM.Common.Application.Abstractions.Authentication;
using PM.Common.Application.Messaging;
using PM.Common.Domain;
using PM.DTM.Domain.Models.Sprints;

namespace PM.DTM.Application.Sprints.Add;

public class AddSprintCommandHandler(IUserContext userContext) : ICommandHandler<AddSprintCommand>
{
	public Task<Result> Handle(AddSprintCommand request, CancellationToken cancellationToken)
	{
		// ToDo:
		// Implement BaseRepository
		// Implement SprintRepository
		// Extract UserId using IUserContext
		// Persist the Sprint in database
		return Task.FromResult(Result.Success());
	}
}