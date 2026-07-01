namespace MotoFlow.Application.Members.UpdateMember
{
    public interface IUpdateMemberUseCase
    {
        Task Execute(Guid id, UpdateMemberRequest body, CancellationToken cancellationToken);
    }
}
