using MotoFlow.Application.Activities.Dtos;

namespace MotoFlow.Application.Activities.GetActivityById;

public interface IGetActivityByIdUseCase
{
    Task<ActivityDto> ExecuteAsync(Guid id, CancellationToken cancellationToken);
}