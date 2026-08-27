namespace MotoFlow.Domain.Entities;

public class Activity
{
    public Guid Id { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public ICollection<ActivityMember> ActivityMembers { get; private set; } = [];

    public Activity(
        string title,
        string? description,
        DateTime startDate,
        DateTime endDate)
    {
        Validate(title, startDate, endDate);

        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
    }

    private Activity()
    {
    }

    public void Update(
        string title,
        string? description,
        DateTime startDate,
        DateTime endDate)
    {
        Validate(title, startDate, endDate);

        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
    }

    public void AddMember(Guid memberId)
    {
        if (ActivityMembers.Any(x => x.MemberId == memberId))
            return;

        ActivityMembers.Add(
            new ActivityMember(Id, memberId));
    }

    public void RemoveMember(Guid memberId)
    {
        var activityMember = ActivityMembers
            .FirstOrDefault(x => x.MemberId == memberId);

        if (activityMember is not null)
            ActivityMembers.Remove(activityMember);
    }

    public void UpdateMembers(IEnumerable<Guid> memberIds)
    {
        var requestedMemberIds = memberIds
            .Distinct()
            .ToHashSet();

        var membersToRemove = ActivityMembers
            .Where(x => !requestedMemberIds.Contains(x.MemberId))
            .ToList();

        foreach (var activityMember in membersToRemove)
        {
            ActivityMembers.Remove(activityMember);
        }

        var currentMemberIds = ActivityMembers
            .Select(x => x.MemberId)
            .ToHashSet();

        foreach (var memberId in requestedMemberIds)
        {
            if (!currentMemberIds.Contains(memberId))
            {
                ActivityMembers.Add(
                    new ActivityMember(Id, memberId));
            }
        }
    }

    private static void Validate(
        string title,
        DateTime startDate,
        DateTime endDate)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException(
                "Activity title is required.",
                nameof(title));

        if (endDate < startDate)
            throw new ArgumentException(
                "End date cannot be earlier than start date.");
    }
}