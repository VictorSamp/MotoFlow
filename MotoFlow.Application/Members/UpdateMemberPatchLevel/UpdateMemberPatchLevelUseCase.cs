using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Domain.Enums;

namespace MotoFlow.Application.Members.UpdateMemberPatchLevel
{
    public class UpdateMemberPatchLevelUseCase : IUpdateMemberPatchLevelUseCase
    {
        private readonly IMemberRepository _memberRepository;

        public UpdateMemberPatchLevelUseCase(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task Execute(Guid id, PatchLevel patchLevel, CancellationToken cancellationToken)
        {
            try
            {
                var member = await _memberRepository.GetByIdAsync(id, cancellationToken) ??
                throw new NotFoundException("Member not found");

                member.UpdatePatchLevel(patchLevel);

                await _memberRepository.SaveChangesAsync(cancellationToken);

            }catch (InvalidOperationException ex)
            {
                throw new BadRequestException(ex.Message);
            }
            
        }
    }
}
