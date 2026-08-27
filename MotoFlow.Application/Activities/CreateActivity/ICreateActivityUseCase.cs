namespace MotoFlow.Application.Activities.CreateActivity;

public interface ICreateActivityUseCase
{
    Task ExecuteAsync(CreateActivityRequest request, CancellationToken cancellationToken);
}