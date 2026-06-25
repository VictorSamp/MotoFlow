using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Members.Interfaces
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAllAsync(CancellationToken cancellationToken);
        Task<Member?> GetByIdAsync(Guid memberId, CancellationToken cancellationToken);
        Task<Member?> GetDetailsByIdAsync(Guid memberId, CancellationToken cancellationToken);
        Task AddAsync(Member member, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken);
    }
}
