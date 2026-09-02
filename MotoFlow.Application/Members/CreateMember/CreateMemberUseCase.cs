using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Commom.Interfaces;
using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Application.MembershipFees.Interfaces;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Members.CreateMember
{
    public class CreateMemberUseCase : ICreateMemberUseCase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMembershipFeeRepository _membershipFeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMemberUseCase(IMemberRepository memberRepository, 
            IMembershipFeeRepository memberFeeRepository,
            IUnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
            _membershipFeeRepository = memberFeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(CreateMemberRequest request, CancellationToken cancellationToken)
        {
            var emailExists = await _memberRepository.EmailExistsAsync(request.Email, cancellationToken);

            if (emailExists)
            {
                throw new EmailExistsException("Email already in use");
            }

            var member = new Member(
                request.Name,
                request.Email,
                request.PhoneNumber);

            var referencePeriod = new DateTime(
                DateTime.UtcNow.Year,
                DateTime.UtcNow.Month,
                1)
                .AddMonths(1);

            var firstFee = new MembershipFee(
                member.Id,
                referencePeriod,
                30.00m);

            await _memberRepository.AddAsync(member, cancellationToken);
            await _membershipFeeRepository.AddAsync(firstFee, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
