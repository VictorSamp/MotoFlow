namespace MotoFlow.Application.Members.ActivateMember
{
    public interface IActivateMemberUseCase
    {
        Task Execute(string id, CancellationToken cancellationToken);
    }
}
