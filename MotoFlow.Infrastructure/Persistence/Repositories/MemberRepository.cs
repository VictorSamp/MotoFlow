using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Domain.Entities;
using MotoFlow.Infrastructure.Data;

namespace MotoFlow.Infrastructure.Persistence.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
