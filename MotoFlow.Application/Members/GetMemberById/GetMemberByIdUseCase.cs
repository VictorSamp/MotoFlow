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

        public async Task<Member> Execute(Guid id, CancellationToken cancellationToken)
        {
            return await _memberRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"Member ID {id} not found.");
        }
    }
}
