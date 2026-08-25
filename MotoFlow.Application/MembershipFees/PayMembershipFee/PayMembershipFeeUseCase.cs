using MotoFlow.Application.Commom.Interfaces;
using MotoFlow.Application.MembershipFees.Interfaces;

namespace MotoFlow.Application.MembershipFees.PayMembershipFee
{
    public class PayMembershipFeeUseCase : IPayMembershipFeeUseCase
    {
        private readonly IMembershipFeeRepository _membershipFeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PayMembershipFeeUseCase(IMembershipFeeRepository membershipFeeRepository, IUnitOfWork unitOfWork)
        {
            _membershipFeeRepository = membershipFeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(string memberId, string feeId, CancellationToken cancellationToken)
        {
            var memberGuid = Guid.Parse(memberId);
            var feeGuid = Guid.Parse(feeId);

            var fee = await _membershipFeeRepository.GetByIdOrThrowAsync(memberGuid, feeGuid, cancellationToken);

            fee.Pay();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
