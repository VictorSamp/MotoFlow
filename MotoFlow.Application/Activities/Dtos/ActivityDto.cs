namespace MotoFlow.Application.Activities.Dtos;

public class ActivityDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<ActivityMemberDto> Members { get; set; } = [];
}