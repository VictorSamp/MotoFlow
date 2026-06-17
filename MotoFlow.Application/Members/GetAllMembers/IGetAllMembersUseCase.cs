using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Members.GetAllMembers
{
    public interface IGetAllMembersUseCase
    {
        public Task<IEnumerable<Member>> Execute(CancellationToken cancellationToken);
    }
}
