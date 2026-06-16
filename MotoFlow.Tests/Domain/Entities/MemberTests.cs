using FluentAssertions;
using MotoFlow.Domain.Entities;
using MotoFlow.Domain.Enums;

namespace MotoFlow.Tests.Domain.Entities
{
    public class MemberTests
    {
        [Fact]
        public void Should_Create_Member_When_Data_Is_Valid()
        {
            var name = "Victor Sampaio";
            var email = "victor@email.com";
            var phoneNumber = "31999999999";

            var member = new Member(name, email, phoneNumber);

            member.Should().NotBeNull();
            member.Id.Should().NotBeEmpty();
            member.Name.Should().Be(name);
            member.Email.Should().Be(email);
            member.PhoneNumber.Should().Be(phoneNumber);
            member.Status.Should().Be(MemberStatus.Active);
            member.JoinDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
            //member.CurrentPatchLevel.Should().Be(PatchLevel.Prospect);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Should_Throw_Exception_When_Name_Is_Invalid(string? name)
        {
            var email = "victor@email.com";
            var phoneNumber = "31999999999";

            Action action = () => new Member(name!, email, phoneNumber);

            action.Should().Throw<ArgumentException>()
                 .WithMessage("Name cannot be null or empty.");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Should_Throw_Exception_When_Email_Is_Invalid(string? email)
        {
            var name = "Victor Sampaio";
            var phoneNumber = "31999999999";

            Action action = () => new Member(name, email!, phoneNumber);

            action.Should().Throw<ArgumentException>()
                .WithMessage("Email cannot be null or empty.");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Should_Throw_Exception_When_Phone_Number_Is_Invalid(string? phoneNumber)
        {
            var name = "Victor Sampaio";
            var email = "victor@email.com";

            Action action = () => new Member(name, email, phoneNumber!);

            action.Should().Throw<ArgumentException>()
                .WithMessage("Phone number cannot be null or empty.");
        }
    }
}