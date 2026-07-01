using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Members.GetMemberById
{
    public interface IGetMemberByIdUseCase
    {
        Task<Member> Execute(Guid id, CancellationToken cancellationToken);
    }
}
