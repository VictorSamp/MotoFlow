using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Members.Interfaces;

namespace MotoFlow.Application.Members.DeleteMember
{
    public class DeleteMemberUseCase : IDeleteMemberUseCase
    {
        private readonly IMemberRepository _memberRepository;

        public DeleteMemberUseCase(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public async Task Execute(Guid id, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"Member ID {id} not found.");

            member.Deactivate();

            await _memberRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
