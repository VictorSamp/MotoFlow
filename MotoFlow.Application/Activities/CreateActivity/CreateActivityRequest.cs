namespace MotoFlow.Application.Activities.CreateActivity;

public record CreateActivityRequest(
    string Title,
    string? Description,
    DateTime StartDate,
    DateTime EndDate,
    List<Guid> MemberIds);