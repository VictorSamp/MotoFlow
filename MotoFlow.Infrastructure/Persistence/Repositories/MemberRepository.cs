using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Member>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Members.ToListAsync(cancellationToken);
        }

        public async Task<Member?> GetByIdAsync(Guid guid, CancellationToken cancellationToken)
        {
            return await _context.Members.FindAsync([guid], cancellationToken);
        }

        public async Task AddAsync(Member member, CancellationToken cancellationToken)
        {
            await _context.Members.AddAsync(member, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
