using MotoFlow.Application.Members.Interfaces;
namespace MotoFlow.Application.Members.GetAllMembers
{
    public class GetAllMembersUseCase : IGetAllMembersUseCase
    {
        private readonly IMemberRepository _memberRepository;

        public GetAllMembersUseCase(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<List<MemberDto>> Execute(CancellationToken cancellationToken)
        {
            var members = await _memberRepository.GetAllAsync(cancellationToken);

            return [.. members.Select(x => new MemberDto{
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                JoinDate = x.JoinDate,
                CurrentPatchLevel = x.CurrentPatchLevel,
                Status = x.Status})
            ];
        }
    }
}
