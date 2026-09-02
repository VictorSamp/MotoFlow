using Moq;
using FluentAssertions;
using MotoFlow.Application.MembershipFees.GetAllMembershipFees;
using MotoFlow.Application.MembershipFees.Interfaces;
using MotoFlow.Domain.Entities;
using MotoFlow.Domain.Enums;

namespace MotoFlow.Tests.Application.MembershipFees.GetAllMembershipFees;

public class GetAllMembershipFeesUseCaseTests
{
    private readonly Mock<IMembershipFeeRepository> _membershipFeeRepository;
    private readonly GetAllMembershipFeesUseCase _useCase;

    public GetAllMembershipFeesUseCaseTests()
    {
        _membershipFeeRepository = new Mock<IMembershipFeeRepository>();
        _useCase = new GetAllMembershipFeesUseCase(_membershipFeeRepository.Object);
    }

    [Fact]
    public async Task Should_Return_Membership_Fees_For_Overview()
    {
        var memberId = Guid.NewGuid();
        var fee = new MembershipFee(
            memberId,
            new DateTime(2026, 10, 1),
            30.00m);

        _membershipFeeRepository
            .Setup(repository => repository.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync([fee]);

        var result = await _useCase.ExecuteAsync(CancellationToken.None);

        result.Should().ContainSingle();
        result[0].Id.Should().Be(fee.Id);
        result[0].MemberId.Should().Be(memberId);
        result[0].ReferencePeriod.Should().Be(new DateTime(2026, 10, 1, 0, 0, 0, DateTimeKind.Utc));
        result[0].Amount.Should().Be(30.00m);
        result[0].Status.Should().Be(MembershipFeeStatus.Pending);
    }
}
