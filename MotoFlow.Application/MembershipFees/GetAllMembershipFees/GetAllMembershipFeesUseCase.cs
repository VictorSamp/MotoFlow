using MotoFlow.Application.MembershipFees.Dtos;
using MotoFlow.Application.MembershipFees.Interfaces;

namespace MotoFlow.Application.MembershipFees.GetAllMembershipFees;

public class GetAllMembershipFeesUseCase : IGetAllMembershipFeesUseCase
{
    private readonly IMembershipFeeRepository _membershipFeeRepository;

    public GetAllMembershipFeesUseCase(
        IMembershipFeeRepository membershipFeeRepository)
    {
        _membershipFeeRepository = membershipFeeRepository;
    }

    public async Task<List<MembershipFeeOverviewDto>> ExecuteAsync(
        CancellationToken cancellationToken)
    {
        var fees = await _membershipFeeRepository.GetAllAsync(cancellationToken);

        return
        [
            .. fees.Select(fee => new MembershipFeeOverviewDto
            {
                Id = fee.Id,
                MemberId = fee.MemberId,
                MemberName = fee.Member?.Name ?? string.Empty,
                ReferencePeriod = fee.ReferencePeriod,
                Amount = fee.Amount,
                PaymentDate = fee.PaymentDate,
                Status = fee.Status
            })
        ];
    }
}
