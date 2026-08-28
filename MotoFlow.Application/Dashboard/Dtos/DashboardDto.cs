using MotoFlow.Domain.Enums;

namespace MotoFlow.Application.Dashboard.Dtos;

public class DashboardDto
{
    public int TotalMembers { get; set; }
    public int ActiveMembers { get; set; }
    public int InactiveMembers { get; set; }
    public int PatchLevelsUsed { get; set; }
    public Dictionary<PatchLevel, int> PatchDistribution { get; set; } = [];
    public List<DashboardMemberDto> RecentMembers { get; set; } = [];
}