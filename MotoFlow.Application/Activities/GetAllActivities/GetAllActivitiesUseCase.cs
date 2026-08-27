using MotoFlow.Application.Activities.Dtos;
using MotoFlow.Application.Activities.Interfaces;

namespace MotoFlow.Application.Activities.GetAllActivities;

public class GetAllActivitiesUseCase : IGetAllActivitiesUseCase
{
    private readonly IActivityRepository _activityRepository;

    public GetAllActivitiesUseCase(
        IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<List<ActivityDto>> ExecuteAsync(CancellationToken cancellationToken)
    {
        var activities = await _activityRepository.GetAllAsync(
            cancellationToken);

        return
        [
            .. activities.Select(activity => new ActivityDto
            {
                Id = activity.Id,
                Title = activity.Title,
                Description = activity.Description,
                StartDate = activity.StartDate,
                EndDate = activity.EndDate,

                Members =
                [
                    .. activity.ActivityMembers.Select(x => new ActivityMemberDto
                    {
                        MemberId = x.MemberId,
                        MemberName = x.Member.Name
                    })
                ]
            })
        ];
    }
}