using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Commom.Interfaces;
using MotoFlow.Application.Members.Interfaces;

namespace MotoFlow.Application.Members.ActivateMember
{
    public class ActivateMemberUseCase : IActivateMemberUseCase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ActivateMemberUseCase(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"Member ID {id} not found.");

            member.Activate();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
