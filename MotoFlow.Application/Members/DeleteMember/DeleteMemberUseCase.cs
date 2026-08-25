using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Commom.Interfaces;
using MotoFlow.Application.Members.Interfaces;

namespace MotoFlow.Application.Members.DeleteMember
{
    public class DeleteMemberUseCase : IDeleteMemberUseCase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMemberUseCase(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Execute(Guid id, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"Member ID {id} not found.");

            member.Deactivate();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
