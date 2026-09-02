using MotoFlow.Application.MembershipFees.Dtos;

namespace MotoFlow.Application.MembershipFees.GetAllMembershipFees;

public interface IGetAllMembershipFeesUseCase
{
    Task<List<MembershipFeeOverviewDto>> ExecuteAsync(CancellationToken cancellationToken);
}
