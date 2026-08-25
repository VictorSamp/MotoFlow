using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Commom.Interfaces;
using MotoFlow.Application.Members.Interfaces;

namespace MotoFlow.Application.Members.UpdateMember
{
    public class UpdateMemberUseCase : IUpdateMemberUseCase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMemberUseCase(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id, UpdateMemberRequest body, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"Member ID {id} not found.");

            member.Update(body.Name, body.PhoneNumber);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
