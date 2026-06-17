using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Members.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllAsync(CancellationToken cancellationToken);
        Task<Member?> GetByIdAsync(Guid guid, CancellationToken cancellationToken);
        Task AddAsync(Member member, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken ct);
        Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken);
    }
}
