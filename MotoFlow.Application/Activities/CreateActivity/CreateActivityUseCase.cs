using MotoFlow.Application.Activities.Interfaces;
using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Commom.Interfaces;
using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Activities.CreateActivity;

public class CreateActivityUseCase : ICreateActivityUseCase
{
    private readonly IActivityRepository _activityRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateActivityUseCase(
        IActivityRepository activityRepository,
        IMemberRepository memberRepository,
        IUnitOfWork unitOfWork)
    {
        _activityRepository = activityRepository;
        _memberRepository = memberRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(
        CreateActivityRequest request,
        CancellationToken cancellationToken)
    {
        var members = await _memberRepository.GetByIdsAsync(
            request.MemberIds,
            cancellationToken);

        if (members.Count != request.MemberIds.Distinct().Count())
            throw new NotFoundException(
                "One or more responsible members were not found.");

        var activity = new Activity(
            request.Title,
            request.Description,
            request.StartDate,
            request.EndDate);

        foreach (var memberId in request.MemberIds)
        {
            activity.AddMember(memberId);
        }

        await _activityRepository.AddAsync(
            activity,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);
    }
}