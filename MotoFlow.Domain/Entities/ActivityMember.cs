namespace MotoFlow.Domain.Entities;

public class ActivityMember
{
    public Guid ActivityId { get; private set; }
    public Guid MemberId { get; private set; }
    public Activity Activity { get; private set; } = null!;
    public Member Member { get; private set; } = null!;

    public ActivityMember(
        Guid activityId,
        Guid memberId)
    {
        ActivityId = activityId;
        MemberId = memberId;
    }

    private ActivityMember()
    {
    }
}