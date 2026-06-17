using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Members.GetAllMembers
{
    public class GetAllMembersUseCase : IGetAllMembersUseCase
    {
        private readonly IMemberRepository _memberRepository;

        public GetAllMembersUseCase(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<Member>> Execute(CancellationToken cancellationToken)
        {
            return await _memberRepository.GetAllAsync(cancellationToken);
        }
    }
}
