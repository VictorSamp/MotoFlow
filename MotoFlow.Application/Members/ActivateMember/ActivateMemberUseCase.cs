using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Domain.Enums;

namespace MotoFlow.Application.Members.ActivateMember
{
    public class ActivateMemberUseCase : IActivateMemberUseCase
    {
        private readonly IMemberRepository _memberRepository;

        public ActivateMemberUseCase(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task Execute(string id, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(id, out var guid))
                throw new BadRequestException("Invalid ID format");

            var member = await _memberRepository.GetByIdAsync(guid, cancellationToken)
                ?? throw new NotFoundException($"Member ID {id} not found.");

            member.Activate();

            await _memberRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
