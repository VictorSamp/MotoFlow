using MotoFlow.Domain.Enums;

namespace MotoFlow.Domain.Entities
{
    public class MembershipFee
    {
        public Guid Id { get; private set; }

        public Guid MemberId { get; private set; }

        public DateTime ReferencePeriod { get; private set; }

        public decimal Amount { get; private set; }

        public DateTime? PaymentDate { get; private set; }

        public MembershipFeeStatus Status { get; private set; }

        public bool IsDeleted { get; private set; }

        public DateTime? DeletedAt { get; private set; }

        public Member? Member { get; private set; }

        public MembershipFee()
        {
            
        }

        public MembershipFee(
            Guid memberId,
            DateTime referencePeriod,
            decimal amount)
        {
            Id = Guid.NewGuid();
            MemberId = memberId;

            Amount = amount;
            Status = MembershipFeeStatus.Pending;
            IsDeleted = false;

            ReferencePeriod = new DateTime(
                referencePeriod.Year,
                referencePeriod.Month,
                1, 0, 0, 0, DateTimeKind.Utc);
        }

        public void Delete()
        {
            if (IsDeleted)
                return;

            if (Status == MembershipFeeStatus.Paid)
                throw new InvalidOperationException(
                    "Paid fees cannot be deleted.");

            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        public void Pay()
        {
            if (IsDeleted)
                throw new InvalidOperationException("Cannot pay a deleted fee.");

            if (Status == MembershipFeeStatus.Paid)
                throw new InvalidOperationException("Fee is already paid.");

            Status = MembershipFeeStatus.Paid;
            PaymentDate = DateTime.UtcNow;
        }
    }
}
