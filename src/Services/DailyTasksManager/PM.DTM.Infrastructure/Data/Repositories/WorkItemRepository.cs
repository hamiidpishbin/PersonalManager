using PM.DTM.Application.Abstractions.Repositories;
using PM.DTM.Domain.Models.WorkItems;

namespace PM.DTM.Infrastructure.Data.Repositories;

public class WorkItemRepository(DTMDbContext dbContext) : DTMRepository<WorkItem>(dbContext), IWorkItemRepository
{

}