using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Members.Interfaces
{
    public interface IMemberRepository
    {
        public Task AddAsync(Member member, CancellationToken cancellationToken);
    }
}
