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
        public async Task Execute(string id, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(id, out var guid))
                throw new BadRequestException("Invalid ID format");

            var member = await _memberRepository.GetByIdAsync(guid, cancellationToken)
                ?? throw new NotFoundException($"Member ID {id} not found.");

            member.Deactivate();

            await _memberRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
