using MotoFlow.Application.Activities.Interfaces;
using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Commom.Interfaces;
using MotoFlow.Application.Members.Interfaces;

namespace MotoFlow.Application.Activities.UpdateActivity;

public class UpdateActivityUseCase : IUpdateActivityUseCase
{
    private readonly IActivityRepository _activityRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateActivityUseCase(
        IActivityRepository activityRepository,
        IMemberRepository memberRepository,
        IUnitOfWork unitOfWork)
    {
        _activityRepository = activityRepository;
        _memberRepository = memberRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(
        Guid id,
        UpdateActivityRequest request,
        CancellationToken cancellationToken)
    {
        var activity = await _activityRepository.GetDetailsByIdAsync(
            id,
            cancellationToken);

        if (activity is null)
            throw new NotFoundException(
                $"Activity ID {id} not found.");

        var members = await _memberRepository.GetByIdsAsync(
            request.MemberIds,
            cancellationToken);

        if (members.Count != request.MemberIds.Distinct().Count())
            throw new NotFoundException(
                "One or more responsible members were not found.");

        activity.Update(
            request.Title,
            request.Description,
            request.StartDate,
            request.EndDate);

        activity.UpdateMembers(request.MemberIds);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);
    }
}