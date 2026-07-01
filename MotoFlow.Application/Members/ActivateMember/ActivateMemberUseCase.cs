using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Members.Interfaces;

namespace MotoFlow.Application.Members.ActivateMember
{
    public class ActivateMemberUseCase : IActivateMemberUseCase
    {
        private readonly IMemberRepository _memberRepository;

        public ActivateMemberUseCase(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task Execute(Guid id, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"Member ID {id} not found.");

            member.Activate();

            await _memberRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
