using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Members.CreateMember
{
    public class CreateMemberUseCase : ICreateMemberUseCase
    {
        private readonly IMemberRepository _memberRepository;

        public CreateMemberUseCase(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task Execute(CreateMemberRequest request)
        {
            var member = new Member(request.Name,
                request.Email,
                request.PhoneNumber
            );

            await _memberRepository.AddAsync(member);
        }
    }
}
