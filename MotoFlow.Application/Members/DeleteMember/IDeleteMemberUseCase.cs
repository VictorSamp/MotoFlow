namespace MotoFlow.Application.Members.DeleteMember
{
    public interface IDeleteMemberUseCase
    {
        Task Execute(string id, CancellationToken cancellationToken);
    }
}
