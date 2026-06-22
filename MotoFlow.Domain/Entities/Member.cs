using MotoFlow.Domain.Enums;

namespace MotoFlow.Domain.Entities
{
    public class Member
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string PhoneNumber { get; private set; }

        public DateTime JoinDate { get; private set; }

        public PatchLevel CurrentPatchLevel { get; private set; }

        public MemberStatus Status { get; private set; }

        public List<MembershipFee> MembershipFees { get; private set; }

        public Member(string name, string email, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be null or empty.");

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            JoinDate = DateTime.UtcNow;
            Status = MemberStatus.Active;
            CurrentPatchLevel = PatchLevel.None;
            MembershipFees = [];
        }

        public void Update(string name, string phoneNumber, PatchLevel patchLevel)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            CurrentPatchLevel = patchLevel;
        }

        public void Activate()
        {
            if (Status == MemberStatus.Active)
                throw new InvalidOperationException("Member already active.");

            Status = MemberStatus.Active;
        }

        public void Deactivate()
        {
            if (Status == MemberStatus.Inactive)
                throw new InvalidOperationException("Member already inactive.");

            Status = MemberStatus.Inactive;
        }
    }
}
