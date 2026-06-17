using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Members.GetAllMembers
{
    public interface IGetAllMembersUseCase
    {
        Task<IEnumerable<Member>> Execute(CancellationToken cancellationToken);
    }
}
