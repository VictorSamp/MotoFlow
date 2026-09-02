using Microsoft.EntityFrameworkCore;
using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.MembershipFees.Interfaces;
using MotoFlow.Domain.Entities;
using MotoFlow.Infrastructure.Data;

namespace MotoFlow.Infrastructure.Persistence.Repositories
{
    public class MembershipFeeRepository : IMembershipFeeRepository
    {
        private readonly AppDbContext _context;

        public MembershipFeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MembershipFee membershipFee, CancellationToken cancellationToken)
        {
            await _context.MembershipFees.AddAsync(membershipFee, cancellationToken);
        }

        public async Task<List<MembershipFee>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.MembershipFees
                .AsNoTracking()
                .Include(x => x.Member)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.ReferencePeriod)
                .ThenBy(x => x.Member!.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> ExistsForMemberAndPeriodAsync(Guid memberId, DateTime referencePeriod, CancellationToken cancellationToken)
        {
            return await _context.MembershipFees
                .AnyAsync(x =>
                    x.MemberId == memberId &&
                    x.ReferencePeriod.Month == referencePeriod.Month &&
                    x.ReferencePeriod.Year == referencePeriod.Year &&
                    !x.IsDeleted, cancellationToken);
        }

        public async Task<MembershipFee> GetByIdOrThrowAsync(Guid memberGuid, Guid feeGuid, CancellationToken cancellationToken)
        {
            return await _context.MembershipFees
                .FirstOrDefaultAsync(mf => mf.MemberId == memberGuid && mf.Id == feeGuid, cancellationToken)
                ?? throw new NotFoundException($"Membership fee with ID {feeGuid} for member {memberGuid} not found.");
        }
    }
}
