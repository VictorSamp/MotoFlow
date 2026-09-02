using FluentAssertions;
using MotoFlow.Domain.Entities;
using MotoFlow.Domain.Enums;

namespace MotoFlow.Tests.Domain.Entities;

public class MembershipFeeTests
{
    [Fact]
    public void Should_Create_Pending_Fee_With_Normalized_Reference_Period()
    {
        var memberId = Guid.NewGuid();
        var referencePeriod = new DateTime(2026, 9, 18);

        var fee = new MembershipFee(memberId, referencePeriod, 30.00m);

        fee.MemberId.Should().Be(memberId);
        fee.ReferencePeriod.Should().Be(new DateTime(2026, 9, 1, 0, 0, 0, DateTimeKind.Utc));
        fee.Amount.Should().Be(30.00m);
        fee.Status.Should().Be(MembershipFeeStatus.Pending);
        fee.IsDeleted.Should().BeFalse();
        fee.PaymentDate.Should().BeNull();
    }

    [Fact]
    public void Should_Pay_Pending_Fee()
    {
        var fee = new MembershipFee(Guid.NewGuid(), DateTime.UtcNow, 30.00m);

        fee.Pay();

        fee.Status.Should().Be(MembershipFeeStatus.Paid);
        fee.PaymentDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void Should_Not_Delete_Paid_Fee()
    {
        var fee = new MembershipFee(Guid.NewGuid(), DateTime.UtcNow, 30.00m);
        fee.Pay();

        Action action = fee.Delete;

        action.Should().Throw<InvalidOperationException>()
            .WithMessage("Paid fees cannot be deleted.");
    }
}
