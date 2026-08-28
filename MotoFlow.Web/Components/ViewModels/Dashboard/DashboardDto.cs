namespace MotoFlow.Web.Components.ViewModels.Dashboard;

public class DashboardDto
{
    public int TotalMembers { get; set; }

    public int ActiveMembers { get; set; }

    public int InactiveMembers { get; set; }

    public int PatchLevelsUsed { get; set; }

    public Dictionary<string, int> PatchDistribution { get; set; } = [];

    public List<RecentMemberDto> RecentMembers { get; set; } = [];
}

public class RecentMemberDto
{
    public string Name { get; set; } = string.Empty;

    public string CurrentPatchLevel { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;
}