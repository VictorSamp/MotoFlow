using MotoFlow.Domain.Enums;

namespace MotoFlow.Application.MembershipFees.Dtos
{
    public class MembershipFeeDto
    {
        public Guid Id { get; set; }

        public DateTime ReferencePeriod { get; set; }

        public decimal Amount { get; set; }

        public DateTime? PaymentDate { get; set; }

        public MembershipFeeStatus Status { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
