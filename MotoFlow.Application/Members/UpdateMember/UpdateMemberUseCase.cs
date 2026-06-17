using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Domain.Enums;

namespace MotoFlow.Application.Members.UpdateMember
{
    public class UpdateMemberUseCase : IUpdateMemberUseCase
    {
        private readonly IMemberRepository _memberRepository;

        public UpdateMemberUseCase(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task Execute(string id, UpdateMemberRequest body, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(id, out var guid))
                throw new BadRequestException("Invalid ID format");

            var member = await _memberRepository.GetByIdAsync(guid, cancellationToken)
                ?? throw new NotFoundException($"Member ID {id} not found.");

            if (!Enum.TryParse<PatchLevel>(body.PatchLevel, true, out var patchLevel))
                throw new BadRequestException("Invalid PatchLevel");

            member.Update(body.Name, body.PhoneNumber, patchLevel);

            await _memberRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
