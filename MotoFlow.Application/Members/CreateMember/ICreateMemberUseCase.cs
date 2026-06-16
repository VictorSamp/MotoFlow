namespace MotoFlow.Application.Members.CreateMember
{
    public interface ICreateMemberUseCase
    {
        Task Execute(CreateMemberRequest request);
    }
}
