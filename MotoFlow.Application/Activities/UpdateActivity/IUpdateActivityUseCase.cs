namespace MotoFlow.Application.Activities.UpdateActivity;

public interface IUpdateActivityUseCase
{
    Task ExecuteAsync(Guid id, UpdateActivityRequest request, CancellationToken cancellationToken);
}