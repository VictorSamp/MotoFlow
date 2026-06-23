using MotoFlow.Application.MembershipFees.Interfaces;

namespace MotoFlow.Application.MembershipFees.PayMembershipFee
{
    public class PayMembershipFeeUseCase : IPayMembershipFeeUseCase
    {
        private readonly IMembershipFeeRepository _membershipFeeRepository;

        public PayMembershipFeeUseCase(IMembershipFeeRepository membershipFeeRepository)
        {
            _membershipFeeRepository = membershipFeeRepository;
        }

        public async Task ExecuteAsync(string memberId, string feeId, CancellationToken cancellationToken)
        {
            var memberGuid = Guid.Parse(memberId);
            var feeGuid = Guid.Parse(feeId);

            var fee = await _membershipFeeRepository.GetByIdOrThrowAsync(memberGuid, feeGuid, cancellationToken);

            fee.Pay();

            await _membershipFeeRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
