using MotoFlow.Domain.Enums;

namespace MotoFlow.Application.Dashboard.Dtos;

public class DashboardMemberDto
{
    public string Name { get; set; } = string.Empty;
    public PatchLevel CurrentPatchLevel { get; set; }
    public MemberStatus Status { get; set; }
}