using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Members.GetMemberById
{
    public class GetMemberByIdUseCase : IGetMemberByIdUseCase
    {
        private readonly IMemberRepository _memberRepository;

        public GetMemberByIdUseCase(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Member> Execute(string id, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(id, out var guid))
                throw new BadRequestException("Invalid member ID format.");

            return await _memberRepository.GetByIdAsync(guid, cancellationToken)
                ?? throw new NotFoundException($"Member ID {id} not found.");
        }
    }
}
