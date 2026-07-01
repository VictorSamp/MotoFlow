using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Members.Interfaces;

namespace MotoFlow.Application.Members.UpdateMember
{
    public class UpdateMemberUseCase : IUpdateMemberUseCase
    {
        private readonly IMemberRepository _memberRepository;

        public UpdateMemberUseCase(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task Execute(Guid id, UpdateMemberRequest body, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"Member ID {id} not found.");

            member.Update(body.Name, body.PhoneNumber, body.PatchLevel);

            await _memberRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
