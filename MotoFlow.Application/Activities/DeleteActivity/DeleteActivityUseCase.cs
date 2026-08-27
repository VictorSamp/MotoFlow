using MotoFlow.Application.Activities.Interfaces;
using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Commom.Interfaces;

namespace MotoFlow.Application.Activities.DeleteActivity;

public class DeleteActivityUseCase : IDeleteActivityUseCase
{
    private readonly IActivityRepository _activityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteActivityUseCase(
        IActivityRepository activityRepository,
        IUnitOfWork unitOfWork)
    {
        _activityRepository = activityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var activity = await _activityRepository.GetByIdAsync(id, cancellationToken) ??
            throw new NotFoundException($"Activity ID {id} not found.");

        _activityRepository.Delete(activity);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);
    }
}