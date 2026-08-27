namespace MotoFlow.Application.Activities.DeleteActivity;

public interface IDeleteActivityUseCase
{
    Task ExecuteAsync(Guid id, CancellationToken cancellationToken);
}