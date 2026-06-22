using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.MembershipFees.Interfaces
{
    public interface IMembershipFeeRepository
    {
        Task AddAsync(MembershipFee membershipFee, CancellationToken cancellationToken);
        Task<MembershipFee> GetByIdOrThrowAsync(Guid memberGuid, Guid feeGuid, CancellationToken cancellationToken);
        Task<bool> ExistsForMemberAndPeriodAsync(Guid memberId, DateTime referencePeriod, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
