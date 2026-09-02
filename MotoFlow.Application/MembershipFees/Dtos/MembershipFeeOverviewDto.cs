using MotoFlow.Domain.Enums;

namespace MotoFlow.Application.MembershipFees.Dtos;

public class MembershipFeeOverviewDto
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public string MemberName { get; set; } = string.Empty;
    public DateTime ReferencePeriod { get; set; }
    public decimal Amount { get; set; }
    public DateTime? PaymentDate { get; set; }
    public MembershipFeeStatus Status { get; set; }
}
