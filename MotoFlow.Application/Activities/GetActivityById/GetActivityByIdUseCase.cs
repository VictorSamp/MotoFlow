using MotoFlow.Application.Activities.Dtos;
using MotoFlow.Application.Activities.Interfaces;
using MotoFlow.Application.Commom.Exceptions;

namespace MotoFlow.Application.Activities.GetActivityById;

public class GetActivityByIdUseCase : IGetActivityByIdUseCase
{
    private readonly IActivityRepository _activityRepository;

    public GetActivityByIdUseCase(
        IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<ActivityDto> ExecuteAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var activity = await _activityRepository.GetDetailsByIdAsync(
            id,
            cancellationToken);

        return activity is null
            ? throw new NotFoundException(
                $"Activity ID {id} not found.")
            : new ActivityDto
        {
            Id = activity.Id,
            Title = activity.Title,
            Description = activity.Description,
            StartDate = activity.StartDate,
            EndDate = activity.EndDate,

            Members = [.. activity.ActivityMembers.Select(x => new ActivityMemberDto
            {
                MemberId = x.MemberId,
                MemberName = x.Member.Name
            })]
        };
    }
}