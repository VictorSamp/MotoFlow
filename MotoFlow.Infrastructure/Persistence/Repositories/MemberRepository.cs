using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Member>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Members
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Member?> GetByIdAsync(Guid memberId, CancellationToken cancellationToken)
        {
            return await _context.Members.FindAsync([memberId], cancellationToken);
        }

        public async Task<Member?> GetDetailsByIdAsync(Guid memberId, CancellationToken cancellationToken)
        {
            return await _context.Members
                .Include(x => x.MembershipFees)
                .FirstOrDefaultAsync(x => x.Id == memberId, cancellationToken);
        }

        public async Task AddAsync(Member member, CancellationToken cancellationToken)
        {
            await _context.Members.AddAsync(member, cancellationToken);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            return _context.Members.AnyAsync(m => m.Email == email, cancellationToken);
        }
    }
}
