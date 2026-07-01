namespace MotoFlow.Application.Members.DeleteMember
{
    public interface IDeleteMemberUseCase
    {
        Task Execute(Guid id, CancellationToken cancellationToken);
    }
}
