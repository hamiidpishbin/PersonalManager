using PM.DTM.Application.WorkItems;
using PM.DTM.Domain.Models.WorkItems;
using PM.DTM.Infrastructure.Data;

namespace PM.DTM.Infrastructure.WorkItems;

public class WorkItemRepository(DTMDbContext dbContext) : DTMRepository<WorkItem>(dbContext), IWorkItemRepository
{

}