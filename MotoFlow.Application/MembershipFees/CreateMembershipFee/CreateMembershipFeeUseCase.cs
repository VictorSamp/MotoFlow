using MotoFlow.Application.Commom.Exceptions;
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

            var feeAlreadyExists = await _membershipFeeRepository.ExistsForMemberAndPeriodAsync(memberGuid,
                createMembershipFeeRequest.ReferencePeriod,
                cancellationToken);

            if (feeAlreadyExists) 
            {
                throw new BadRequestException("A fee already exists for this member in this period.");
            }

            var fee = new MembershipFee(memberGuid,
                createMembershipFeeRequest.ReferencePeriod,
                createMembershipFeeRequest.Amount);

            await _membershipFeeRepository.AddAsync(fee, cancellationToken);
            await _membershipFeeRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
