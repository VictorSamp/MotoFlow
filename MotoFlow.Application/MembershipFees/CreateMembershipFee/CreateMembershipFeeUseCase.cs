using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Commom.Interfaces;
using MotoFlow.Application.MembershipFees.Interfaces;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.MembershipFees.CreateMembershipFee
{
    public class CreateMembershipFeeUseCase : ICreateMembershipFeeUseCase
    {
        private readonly IMembershipFeeRepository _membershipFeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateMembershipFeeUseCase(IMembershipFeeRepository membershipFeeRepository, IUnitOfWork unitOfWork)
        {
            _membershipFeeRepository = membershipFeeRepository;
            _unitOfWork = unitOfWork;
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
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
