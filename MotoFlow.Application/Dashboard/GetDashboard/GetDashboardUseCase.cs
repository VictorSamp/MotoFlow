using MotoFlow.Application.Dashboard.Dtos;
using MotoFlow.Application.Members.Interfaces;

namespace MotoFlow.Application.Dashboard.GetDashboard;

public class GetDashboardUseCase : IGetDashboardUseCase
{
    private readonly IMemberRepository _memberRepository;

    public GetDashboardUseCase(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<DashboardDto> Execute(CancellationToken cancellationToken)
    {
        var members = await _memberRepository.GetAllAsync(cancellationToken);

        var dashboard = new DashboardDto
        {
            TotalMembers = members.Count,

            ActiveMembers =
                members.Count(x =>
                    x.Status == Domain.Enums.MemberStatus.Active),

            InactiveMembers =
                members.Count(x =>
                    x.Status == Domain.Enums.MemberStatus.Inactive),

            PatchLevelsUsed =
                members
                    .Select(x => x.CurrentPatchLevel)
                    .Distinct()
                    .Count(),

            PatchDistribution =
                members
                    .GroupBy(x => x.CurrentPatchLevel)
                    .ToDictionary(
                        x => x.Key,
                        x => x.Count()),

            RecentMembers =
                members
                    .Take(5)
                    .Select(x => new DashboardMemberDto
                    {
                        Name = x.Name,
                        CurrentPatchLevel = x.CurrentPatchLevel,
                        Status = x.Status
                    })
                    .ToList()
        };

        return dashboard;
    }
}