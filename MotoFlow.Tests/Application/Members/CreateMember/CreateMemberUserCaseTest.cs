using Moq;
using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Commom.Interfaces;
using MotoFlow.Application.Members.CreateMember;
using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Application.MembershipFees.Interfaces;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Tests.Application.Members.CreateMember;

public class CreateMemberUseCaseTests
{
    private readonly Mock<IMemberRepository> _memberRepository;
    private readonly Mock<IMembershipFeeRepository> _membershipFeeRepository;
    private readonly Mock<IUnitOfWork> _unitOfWork;

    private readonly CreateMemberUseCase _useCase;

    public CreateMemberUseCaseTests()
    {
        _memberRepository = new Mock<IMemberRepository>();
        _membershipFeeRepository = new Mock<IMembershipFeeRepository>();
        _unitOfWork = new Mock<IUnitOfWork>();

        _useCase = new CreateMemberUseCase(
            _memberRepository.Object,
            _membershipFeeRepository.Object,
            _unitOfWork.Object);
    }

    [Fact]
    public async Task Should_Create_Member_And_First_MembershipFee()
    {
        var request = new CreateMemberRequest(
                "Victor",
                "victor@email.com",
                "31999999999");

        _memberRepository
            .Setup(x => x.EmailExistsAsync(
                request.Email,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        await _useCase.Execute(
            request,
            CancellationToken.None);

        _memberRepository.Verify(
            x => x.AddAsync(
                It.Is<Member>(member =>
                    member.Name == request.Name &&
                    member.Email == request.Email &&
                    member.PhoneNumber == request.PhoneNumber),
                It.IsAny<CancellationToken>()),
            Times.Once);

        _membershipFeeRepository.Verify(
            x => x.AddAsync(
                It.Is<MembershipFee>(fee =>
                    fee.Amount == 30.00m &&
                    fee.ReferencePeriod.Month == DateTime.UtcNow.Month &&
                    fee.ReferencePeriod.Year == DateTime.UtcNow.Year),
                It.IsAny<CancellationToken>()),
            Times.Once);

        _unitOfWork.Verify(
            x => x.SaveChangesAsync(
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Should_Not_Create_Member_When_Email_Already_Exists()
    {
        var request = new CreateMemberRequest(
                "Victor",
                "victor@email.com",
                "31999999999");

        _memberRepository
            .Setup(x => x.EmailExistsAsync(
                request.Email,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var act = () => _useCase.Execute(
            request,
            CancellationToken.None);

        await Assert.ThrowsAsync<EmailExistsException>(act);

        _memberRepository.Verify(
            x => x.AddAsync(
                It.IsAny<Member>(),
                It.IsAny<CancellationToken>()),
            Times.Never);

        _membershipFeeRepository.Verify(
            x => x.AddAsync(
                It.IsAny<MembershipFee>(),
                It.IsAny<CancellationToken>()),
            Times.Never);

        _unitOfWork.Verify(
            x => x.SaveChangesAsync(
                It.IsAny<CancellationToken>()),
            Times.Never);
    }
}