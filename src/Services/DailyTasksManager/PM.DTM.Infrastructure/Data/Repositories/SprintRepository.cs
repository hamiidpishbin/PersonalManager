using PM.DTM.Application.Abstractions.Repositories;
using PM.DTM.Domain.Models.Sprints;

namespace PM.DTM.Infrastructure.Data.Repositories;

public class SprintRepository(DTMDbContext dbContext) : DTMRepository<Sprint>(dbContext), ISprintRepository
{
	
}