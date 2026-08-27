using MotoFlow.Application.Activities.Dtos;

namespace MotoFlow.Application.Activities.GetAllActivities;

public interface IGetAllActivitiesUseCase
{
    Task<List<ActivityDto>> ExecuteAsync(CancellationToken cancellationToken);
}