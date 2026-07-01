namespace MotoFlow.Application.Members.ActivateMember
{
    public interface IActivateMemberUseCase
    {
        Task Execute(Guid id, CancellationToken cancellationToken);
    }
}
