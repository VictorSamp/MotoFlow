namespace MotoFlow.Application.Members.GetAllMembers
{
    public interface IGetAllMembersUseCase
    {
        Task<List<MemberDto>> Execute(CancellationToken cancellationToken);
    }
}
