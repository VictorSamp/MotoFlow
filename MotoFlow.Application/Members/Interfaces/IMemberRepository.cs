using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Members.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAll(CancellationToken cancellationToken);
        Task<Member?> GetByIdAsync(Guid guid, CancellationToken cancellationToken);
        Task AddAsync(Member member, CancellationToken cancellationToken);
    }
}
