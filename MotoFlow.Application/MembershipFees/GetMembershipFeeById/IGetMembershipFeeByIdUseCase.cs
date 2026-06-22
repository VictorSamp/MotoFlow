using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.MembershipFees.GetMembershipFeeById
{
    public interface IGetMembershipFeeByIdUseCase
    {
        Task<MembershipFee> ExecuteAsync(string memberId, string feeId, CancellationToken cancellationToken);
    }
}
