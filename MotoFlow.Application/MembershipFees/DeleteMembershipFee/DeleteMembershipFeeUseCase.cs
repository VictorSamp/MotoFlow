using MotoFlow.Application.MembershipFees.Interfaces;

namespace MotoFlow.Application.MembershipFees.DeleteMembershipFee
{
    public class DeleteMembershipFeeUseCase : IDeleteMembershipFeeUseCase
    {
        private readonly IMembershipFeeRepository _membershipFeeRepository;
        public DeleteMembershipFeeUseCase(IMembershipFeeRepository membershipFeeRepository)
        {
            _membershipFeeRepository = membershipFeeRepository;
        }

        public async Task ExecuteAsync(string memberId, string feeId, CancellationToken cancellationToken)
        {
            var memberGuid = Guid.Parse(memberId);
            var feeGuid = Guid.Parse(feeId);

            var fee = await _membershipFeeRepository.GetByIdOrThrowAsync(memberGuid, feeGuid, cancellationToken);

            fee.Delete();

            await _membershipFeeRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
