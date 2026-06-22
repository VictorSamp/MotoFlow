using MotoFlow.Application.MembershipFees.Interfaces;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.MembershipFees.CreateMembershipFee
{
    public class CreateMembershipFeeUseCase : ICreateMembershipFeeUseCase
    {
        private readonly IMembershipFeeRepository _membershipFeeRepository;
        public CreateMembershipFeeUseCase(IMembershipFeeRepository membershipFeeRepository)
        {
          _membershipFeeRepository = membershipFeeRepository;
        }

        public async Task ExecuteAsync(string memberId, CreateMembershipFeeRequest createMembershipFeeRequest, CancellationToken cancellationToken)
        {
            var memberGuid = Guid.Parse(memberId);

            var fee = new MembershipFee(memberGuid, createMembershipFeeRequest.ReferencePeriod,
                createMembershipFeeRequest.Amount);

            await _membershipFeeRepository.AddAsync(fee, cancellationToken);
            await _membershipFeeRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
