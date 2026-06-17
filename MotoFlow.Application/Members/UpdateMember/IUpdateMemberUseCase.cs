namespace MotoFlow.Application.Members.UpdateMember
{
    public interface IUpdateMemberUseCase
    {
        Task Execute(string id, UpdateMemberRequest body, CancellationToken cancellationToken);
    }
}
