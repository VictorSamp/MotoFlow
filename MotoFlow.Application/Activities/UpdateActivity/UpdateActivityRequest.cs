namespace MotoFlow.Application.Activities.UpdateActivity;

public record UpdateActivityRequest(
    string Title,
    string? Description,
    DateTime StartDate,
    DateTime EndDate,
    List<Guid> MemberIds);