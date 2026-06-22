using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Application.MembershipFees.Interfaces;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.MembershipFees.GetMembershipFeeById
{
    public class GetMembershipFeeByIdUseCase : IGetMembershipFeeByIdUseCase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMembershipFeeRepository _membershipFeeRepository;

        public GetMembershipFeeByIdUseCase(IMemberRepository memberRepository,
            IMembershipFeeRepository membershipFeeRepository)
        {
            _memberRepository = memberRepository;
            _membershipFeeRepository = membershipFeeRepository;
        }

        public async Task<MembershipFee> ExecuteAsync(string memberId, string feeId, CancellationToken cancellationToken)
        {
            var memberGuid = Guid.Parse(memberId);
            var feeGuid = Guid.Parse(feeId);

            return await _membershipFeeRepository.GetByIdOrThrowAsync(memberGuid, feeGuid, cancellationToken);
        }
    }
}
